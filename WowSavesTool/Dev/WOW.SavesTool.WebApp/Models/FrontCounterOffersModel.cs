using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WOW.SaveTool.Data.ProductQuery;

namespace WOW.SavesTool.WebApp.Models
{
    public class FrontCounterOffersModel
    {
        public FrontCounterOffer GoodwillOffer { get; set; }
        public FrontCounterOffer ProactiveOffer { get; set; }
        public FrontCounterOffer Discount1Offer { get; set; }
        public FrontCounterOffer Loyalty1Offer { get; set; }
        public FrontCounterOffer TransferToLoyalty { get; set; }
        public CustomerModel CustomerModel { get; set; }
        public int SavesLogId { get; set; }
        public bool DisconnectAccepted { get; set; }
    }

     public class FrontCounterOffer
    {
        public decimal Amount { get; set; }
        public bool WasOffered { get; set; }
        public bool WasAccepted { get; set; }
    }
}