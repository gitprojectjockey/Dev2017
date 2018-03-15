using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXmlLoadFromFile
{
    public class ShippingInfo
    {
      public string ShippedDate { get; set; }
      public int ShipVia { get; set; }
      public double Freight { get; set; }
      public string ShipName { get; set; }
      public string ShipAddress { get; set; }
      public string ShipCity { get; set; }
      public string ShipRegion { get; set; }
      public string ShipPostalCode { get; set; }
      public string ShipCountry { get; set; }
    }
}
