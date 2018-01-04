using System;
using System.Security.AccessControl;

namespace WOW.SavesTool.WebApp.Models
{
    public class EtfModel
    {
        public decimal EtfAmount { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        public CustomerModel CustomerModel { get; set; }
    }
}