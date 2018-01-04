using System.Collections.Generic;
using System.Web.Mvc;
using WOW.SaveTool.Data.ProductQuery;

namespace WOW.SavesTool.WebApp.Models
{
    public class LoyaltyOffersModel
    {
        public CustomerModel CustomerModel { get; set; }
        public LoyaltyOffer Loyalty1Offer { get; set; }
        public LoyaltyOffer Loyalty2Offer { get; set; }
        public LoyaltyOffer ContractOffer { get; set; }
        public LoyaltyOffer TwelveMonthContract { get; set; }

        public bool DisconnectAccepted { get; set; }
        public bool CustomerCallBackAccepted { get; set; }
        public int SavesLogId { get; set; }
       

        public List<SelectListItem> LoyaltyHsdSpeeds { get; set; }
        public List<SelectListItem> LoyaltyCableSizes { get; set; }
        public List<SelectListItem> LoyaltyPhoneOptions { get; set; }
        public List<SelectListItem> FiveYearDiscountAmts { get; set; }

        public string SelectedHsd{ get; set; }
        public string SelectedCable { get; set; }
        public string SelectedPhone { get; set; }
        public string SelectedFiveYearDiscountAmt { get; set; }
    }

    public class LoyaltyOffer
    {
        public decimal Amount { get; set; }
        public bool WasOffered { get; set; }
        public bool WasAccepted { get; set; }
    }

    public class LoyaltyHsdSpeed
    {
        public string Id { get; set; }
        public string DisplayText{ get; set; }
    }

    public class LoyaltyCableSize
    {
        public string Id { get; set; }
        public string DisplayText { get; set; }
    }

    public class LoyaltyPhoneOption
    {
        public string Id { get; set; }
        public string DisplayText { get; set; }
    }
}