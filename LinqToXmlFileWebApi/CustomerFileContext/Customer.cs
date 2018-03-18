using CustomerFileContext.BaseClasses;
using System;
using System.Collections.Generic;

namespace CustomerFileContext
{
    public class Customer : CustomerIdentityBase
    {
        
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public CustomerAddress FullAddress { get; set; }
        public Lazy<List<Order>> LazyOrders { get; set; }
    }
}
