using WOW.SaveTool.Data.ProductCommand;

namespace WOW.SaveTool.Data
{
    public interface ILogRepository
    {
        void LogSaveOffers(OfferList[] offerList, int saveLogId, string hsdSpeed, string phoneOption, string cableOption, string callAction, decimal fiveYearDiscountAmt, bool isTwelveMonthContract);
    }
}