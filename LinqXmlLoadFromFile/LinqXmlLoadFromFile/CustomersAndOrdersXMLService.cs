using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LinqXmlLoadFromFile
{
    public class CustomersAndOrdersXMLService
    {
        private readonly string _fileName;
        private readonly XDocument _document;
        public CustomersAndOrdersXMLService()
        {
            _fileName = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\CustomersAndOrders.xml";
            _document = XDocument.Load(_fileName);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _document.Descendants("Customer").Select(c => new Customer
            {
                CustomerID = c.Attribute("CustomerID").Value,
                CompanyName = c.Element("CompanyName").Value,
                ContactName = c.Element("ContactName").Value,
                ContactTitle = c.Element("ContactTitle").Value,
                Phone = c.Element("Phone").Value,
                FullAddress = new CustomerAddress()
                {
                    Address = c.Element("FullAddress").Element("Address").Value,
                    City = c.Element("FullAddress").Element("City").Value,
                    Country = c.Element("FullAddress").Element("Country").Value,
                    PostalCode = c.Element("FullAddress").Element("PostalCode").Value,
                    Region = c.Element("FullAddress").Element("Region").Value,
                }
            });
            return customers;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _document.Descendants("Order").Select(o => new Order
            {
                CustomerID = o.Element("CustomerID").Value,
                EmployeeID = Convert.ToInt32(o.Element("EmployeeID").Value),
                OrderDate = Convert.ToDateTime(o.Element("OrderDate").Value),
                ETA = Convert.ToDateTime(o.Element("RequiredDate").Value),
                ShippingInformation = new ShippingInfo()
                {
                    ShippedDate = o.Element("ShipInfo").Attributes("ShippedDate").Select(sd => sd.Value).FirstOrDefault(),
                    ShipVia = Convert.ToInt32(o.Element("ShipInfo").Element("ShipVia").Value),
                    Freight = Convert.ToDouble(o.Element("ShipInfo").Element("Freight").Value),
                    ShipName = o.Element("ShipInfo").Element("ShipName").Value,
                    ShipAddress = o.Element("ShipInfo").Element("ShipAddress").Value,
                    ShipCity = o.Element("ShipInfo").Element("ShipCity").Value,
                    ShipRegion = o.Element("ShipInfo").Element("ShipRegion").Value,
                    ShipPostalCode = o.Element("ShipInfo").Element("ShipPostalCode").Value,
                    ShipCountry = o.Element("ShipInfo").Element("ShipCountry").Value
                }
            });
            return orders;
        }
    }
}
