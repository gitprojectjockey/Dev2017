using CustomerFileContext.BaseClasses;
using System;

namespace CustomerFileContext
{ 
    public class Order : CustomerIdentityBase
    {
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ETA { get; set; }
        public ShippingInfo ShippingInformation { get; set; }
    }
}
