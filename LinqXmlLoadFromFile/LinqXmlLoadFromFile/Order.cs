using System;

namespace LinqXmlLoadFromFile
{
    public class Order
    {
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ETA { get; set; }
        public ShippingInfo ShippingInformation { get; set; }
    }
}
