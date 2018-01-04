using System;
using log4net;
using log4net.Repository.Hierarchy;
using WOW.SaveTool.Data.ProductCommand;

namespace WOW.SaveTool.Data
{
    public class LogRepository : ILogRepository
    {
        private readonly IProductCommand _productCommand;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(LogRepository));
        public LogRepository(IProductCommand productCommand)
        {
            _productCommand = productCommand;
        }

        public void LogSaveOffers(OfferList[] offerList, int saveLogId, string hsdSpeed, string phoneOption, string cableOption, string callAction, decimal fiveYearDiscountAmt, bool isTwelveMonthContract)
        {
            try
            {
                var request = new LogOffersRequest();
                request.Offers = offerList;
                request.SaveLogId = saveLogId;
                request.CableOption = cableOption;
                request.InternetOption = hsdSpeed;
                request.CallAction = callAction;
                request.FiveYearDiscountAmount = fiveYearDiscountAmt;
                request.Is12MonthContract = isTwelveMonthContract;
                request.CallAction = callAction;


                _productCommand.LogOffers(request);
            }

            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}