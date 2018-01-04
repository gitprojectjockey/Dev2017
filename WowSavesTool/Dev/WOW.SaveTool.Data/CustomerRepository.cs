using System;
using System.IO;
using System.Runtime.Caching;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Xml.Serialization;
using log4net;
using Polly;
using WOW.SaveTool.Data.Customer;
using WOW.SaveTool.Data.ProductCommand;
using WOW.SaveTool.Data.ProductQuery;

namespace WOW.SaveTool.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CustomerRepository));
        private static readonly ObjectCache MemoryCache = System.Runtime.Caching.MemoryCache.Default;
        private readonly ICustomer _customer;
        private readonly IProductQuery _productQuery;
        private readonly IProductCommand _productCommand;

        public CustomerRepository(ICustomer customer, IProductQuery productQuery, IProductCommand productCommand)
        {
            _customer = customer;
            _productQuery = productQuery;
            _productCommand = productCommand;
        }

        public CustomerDetailsResponse GetCustomerInformation(string accountNumber, string username)
        {
            try
            {
                var customerDetailsResponse =
                    MemoryCache.Get("CustomerDetails_" + accountNumber) as CustomerDetailsResponse;

                if (customerDetailsResponse != null)
                {
                    return customerDetailsResponse;
                }

                var request = new CustomerDetailsByAccountNumberRequest
                {
                    AccountNumber = accountNumber,
                    UserName = username,
                    Services =
                        new[]
                        {
                            Service.Account,
                            Service.ServiceAddress,
                            Service.Billing,
                            Service.Cable,
                            Service.Internet,
                            Service.Phone,
                            Service.Package,
                            Service.Equipment,
                            Service.OtherAttributes
                        }
                };

                var result = _customer.CustomerDetailsByAccountNumber(request);

                if (result != null && result.Account != null)
                {
                    result.Account.AccountNumber = accountNumber;
                    MemoryCache.Add("CustomerDetails_" + accountNumber, result,
                        new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddMinutes(60)) });
                }

                return result;
            }
            catch (FaultException<Customer.ParameterFaultException> ex)
            {
                Logger.Error(ex);
                return null;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public decimal GetCustomerEtfData(DateTime startDate, DateTime endDate)
        {
            var timeSpan = endDate.Subtract(startDate);
            var daysDiff = timeSpan.Days;

            //if the days under contract are 30 or less, there is no ETF fee 
            if (daysDiff <= 30)
            {
                return 0;
            }

            //find the months difference
            var monthDiff = 12 * (endDate.Year - startDate.Year) + endDate.Month - startDate.Month;

            //if the day of the month of the stop date is equal or later then we are in the next month as there is no proration
            if (endDate.Day >= startDate.Day)
            {
                monthDiff += 1;
            }

            //if end date is outside of contract then there is no ETF fee
            if (monthDiff >= 13)
            {
                return 0;
            }

            return Convert.ToDecimal(15 * (13 - monthDiff));
        }

        public int GetCustomerRatingData(string accountNumber)
        {
            try
            {
                var result = MemoryCache.Get("CustomerRating_" + accountNumber);
                if (result != null)
                {
                    return (int) result;
                }

                var customerRatingRequest = new CustomerRatingRequest {AccountNumber = accountNumber};
                var policy = Policy.Handle<TimeoutException>().Retry(2);

                var customerRating = policy.Execute(() => _productQuery.GetCustomerRating(customerRatingRequest));

                    MemoryCache.Add("CustomerRating_" + accountNumber, customerRating,
                    new CacheItemPolicy {AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddMinutes(60))});

                return customerRating;
            }
            catch (TimeoutException ex)
            {
                Logger.Error(ex);
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0; 
            }
        }

        public decimal GetCustomerRateIncrease(string accountNumber,Package[] accountPackage, string marketId, bool isCable, bool isPhone, bool isInternet)
        {
            try
            {
                var cachedResult = MemoryCache.Get("CustomerRateIncrease_" + accountNumber);
                if (cachedResult != null)
                {
                    return (decimal)cachedResult;
                }

                var rateIncreaseRequest = new GetRateIncreaseRequest
                {
                    AccountPackage = accountPackage,
                    IsCable = isCable,
                    IsInternet = isInternet,
                    IsPhone = isPhone,
                    MarketId = Convert.ToInt32(marketId)
                };

                var rateIncreaseResponse = _productQuery.GetRateIncrease(rateIncreaseRequest);
                MemoryCache.Add("CustomerRateIncrease_" + accountNumber, rateIncreaseResponse.Amount,
                   new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddMinutes(60)) });
                return rateIncreaseResponse.Amount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public Offers[] GetOffers(Package[] accountPackage, int starRating, int marketId, int tenure, bool isCable,
            bool isPhone, bool isInternet, EnumsOfferGroup offerGroup, int savesLogId)
        {
            try
            {
                var offersRequest = new GetOfferRequest
                {
                    AccountPackage = accountPackage,
                    StarRating = starRating,
                    MarketId = marketId,
                    Tenure = tenure,
                    IsCable = isCable,
                    IsInternet = isInternet,
                    IsPhone = isPhone,
                    OfferGroup = offerGroup,
                    SaveLogId = savesLogId
                };


                var getOffersResponse = _productQuery.GetOffers(offersRequest);

                //string objectToString;

                //XmlSerializer xmlSerializer = new XmlSerializer(offersRequest.GetType());

                //using (StringWriter textWriter = new StringWriter())
                //{
                //    xmlSerializer.Serialize(textWriter, offersRequest);
                //    objectToString = textWriter.ToString();
                //}
                return getOffersResponse.Offers;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }


        public int GetSaveLogId(string accountNumber,string userName)
        {
            try
            {
                var request = new SaveLogAccountNumberRequest
                {
                    AccountNumber = accountNumber,
                    LoginId = userName
                };

                var response = _productCommand.LogAccountNumber(request);

                return response.SaveLogId;
            }
            catch (Exception ex)
            {
               Logger.Error(ex);
               throw;
            }
        }
    }
}
