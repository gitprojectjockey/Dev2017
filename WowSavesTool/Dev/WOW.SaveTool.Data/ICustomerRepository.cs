using WOW.SaveTool.Data.Customer;
using System;
using WOW.SaveTool.Data.ProductQuery;

namespace WOW.SaveTool.Data
{
    public interface ICustomerRepository
    {
        CustomerDetailsResponse GetCustomerInformation(string accountNumber, string username);
        decimal GetCustomerEtfData(DateTime startDate, DateTime endDate);
        int GetCustomerRatingData(string accountNumber);

        decimal GetCustomerRateIncrease(string accountNumber, Package[] accountPackage, string marketId, bool isCable, bool isPhone, bool isInternet);

        Offers[] GetOffers(Package[] accountPackage, int starRating, int marketId, int tenure, bool isCable,
            bool isPhone, bool isInternet, EnumsOfferGroup offerGroup, int savesLogId);

        int GetSaveLogId(string accountNumber, string userName);
    }
}