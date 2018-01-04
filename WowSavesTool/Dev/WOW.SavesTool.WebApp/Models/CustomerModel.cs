using System;
using System.Collections.Generic;
using WOW.SaveTool.Data.Customer;

namespace WOW.SavesTool.WebApp.Models
{
    public class CustomerModel
    {
        public string AccountNumber { get; set; }

        public string AccountStatus { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public AutoPay AutoPay { get; set; }

        public BillingSystem BillingSystem { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public double CurrentBalance { get; set; }

        public string CustomerName { get; set; }

        public string DayTimePhoneNumber { get; set; }

        public int DelinquencyDays { get; set; }

        public DateTime DueDate { get; set; }

        public string EveningPhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double LastPaymentAmount { get; set; }

        public DateTime LastPaymentDate { get; set; }

        public double PastDue { get; set; }

        public double PendingAmount { get; set; }

        public string Postalcode { get; set; }

        public string State { get; set; }

        public double TotalDue { get; set; }

        public string ContactEmail { get; set; }

        public List<PackageInfoModel> PackageInfoModels { get; set; }

        public double LastStatementAmount { get; set; }

        public DateTime LastStatementDate { get; set; }

        public int Rating { get; set; }

        public decimal RateIncrease { get; set; }

        public int SaveLogId { get; set; }
      
    }

    public class PackageInfoModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Type { get; set; }
    }
}