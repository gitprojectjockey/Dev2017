
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace LinqToXmlFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName =($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\CustomersAndOrders.xml");
            string xsdfileName = ($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\CustomersAndOrders.xsd");

            var schemaErrors = string.Empty;
            CustomerFileContext.ICustomerOrderFileService customerOrderFileService = new CustomerFileContext.CustomerOrderFileService(fileName);
            bool valid = customerOrderFileService.IsSchemaValid(xsdfileName, out schemaErrors);

            List<CustomerFileContext.Customer> customers = customerOrderFileService.Customers.ToList();
            List<CustomerFileContext.Order> orders = customerOrderFileService.Orders.ToList();
            CustomerFileContext.Customer customer = customerOrderFileService.CustomerWithOrders("LETSS");

            foreach (var o in customer.LazyOrders.Value)
            {
                string customerId = o.CustomerID;
            }

            customerOrderFileService.Dispose();
        }
    }
}
