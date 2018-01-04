using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WOW.SaveTool.Data.ProductQuery;

namespace WOW.SavesTool.WebApp.Models
{
    public class CallCenterOffersModel
    {
        public bool DisconnectAccepted{ get; set; }
        public int SavesLogId{ get; set; }
        public CallCenterOffer GoodwillOffer { get; set; }
        public CallCenterOffer ProactiveOffer { get; set; }
        public CallCenterOffer Discount1Offer { get; set; }
        public CallCenterOffer TransferToLoyalty { get; set; }

        public CustomerModel CustomerModel { get; set; }
    }

    public class CallCenterOffer
    {
       public decimal Amount { get; set; }
       public bool WasOffered { get; set; }
       public bool WasAccepted { get; set; }
    }
}