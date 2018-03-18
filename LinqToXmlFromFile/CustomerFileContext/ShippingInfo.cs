using CustomerFileContext.BaseClasses;

namespace CustomerFileContext
{

    public class ShippingInfo : AddressBase
        {
            public string ShippedDate { get; set; }
            public int ShipVia { get; set; }
            public double Freight { get; set; }
            public string ShipName { get; set; }
        }
    
}
