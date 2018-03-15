using System.Collections.Generic;
using System.Linq;

namespace LinqXmlLoadFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var customersAndOrdersXmlService = new CustomersAndOrdersXMLService();

            List<Customer> customers = customersAndOrdersXmlService.GetCustomers().ToList();
            List<Order> orders = customersAndOrdersXmlService.GetOrders().ToList();
        }
    }
}
