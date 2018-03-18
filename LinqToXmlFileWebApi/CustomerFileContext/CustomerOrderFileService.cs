using CustomerFileContext.BaseClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace CustomerFileContext
{
    public class CustomerOrderFileService : XMLFileServiceBase, IDisposable, ICustomerOrderFileService
    {
        private  XDocument _document;

        #region Constructors

        public CustomerOrderFileService(string fileName)
        {
            _document = base.Load(fileName);
        }

        public CustomerOrderFileService(Stream fileStream)
        {
            _document = base.Load(fileStream);
        }

        public CustomerOrderFileService(TextReader textReader)
        {
            _document = base.Load(textReader);
        }

        public CustomerOrderFileService(XmlReader xmlReader)
        {
            _document = base.Load(xmlReader);
        }

        public CustomerOrderFileService(Uri uri)
        {
            _document = base.Load(uri);
        }

        #endregion

        #region Public Interface

        public List<Customer> Customers
        {
            get { return GetCustomers().ToList(); }
        }

        public Customer Customer(string customerId)
        {
            return GetCustomer(customerId);
        }

        public List<Order> Orders
        {
            get { return GetOrders().ToList(); }
        }

        public Customer CustomerWithOrders(string customerId)
        {
            return GetCustomerWithLazyOrders(customerId);
        }

        public override void Dispose()
        {
            if (_document != null) _document = null;
        }

        public bool IsSchemaValid(string schemaFile, out string schemaErrors)
        {
            return base.IsSchemaValid(schemaFile, _document, out schemaErrors);
        }

        #endregion

        #region Private Methods

        private List<Customer> GetCustomers()
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
            return customers.ToList();
        }

        private Customer GetCustomer(string customerId)
        {
            var customer = _document.Descendants("Customer").Select(c => new Customer
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
            }).Where(c => c.CustomerID == customerId).FirstOrDefault();
            return customer;
        }

        private List<Order> GetOrders()
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
                    Address = o.Element("ShipInfo").Element("ShipAddress").Value,
                    City = o.Element("ShipInfo").Element("ShipCity").Value,
                    Region = o.Element("ShipInfo").Element("ShipRegion").Value,
                    PostalCode = o.Element("ShipInfo").Element("ShipPostalCode").Value,
                    Country = o.Element("ShipInfo").Element("ShipCountry").Value
                }
            });
            return orders.ToList();
        }

        private List<Order> GetOrdersByCustomer(string customerId)
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
                    Address = o.Element("ShipInfo").Element("ShipAddress").Value,
                    City = o.Element("ShipInfo").Element("ShipCity").Value,
                    Region = o.Element("ShipInfo").Element("ShipRegion").Value,
                    PostalCode = o.Element("ShipInfo").Element("ShipPostalCode").Value,
                    Country = o.Element("ShipInfo").Element("ShipCountry").Value
                }
            }).Where(o=>o.CustomerID==customerId);
            return orders.ToList();
        }

        private Customer GetCustomerWithLazyOrders(string customerId)
        {
            var customer = _document.Descendants("Customer").Select(c => new Customer
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
            }).Where(c => c.CustomerID == customerId).FirstOrDefault();

            customer.LazyOrders = new Lazy<List<Order>>(() =>  GetOrdersByCustomer(customerId));

            return customer;
        }

        #endregion
    }
}
