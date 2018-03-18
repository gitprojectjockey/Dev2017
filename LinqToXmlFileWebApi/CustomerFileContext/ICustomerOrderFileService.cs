using System.Collections.Generic;

namespace CustomerFileContext
{
    public interface ICustomerOrderFileService
    {
        List<Customer> Customers { get; }

        List<Order> Orders { get; }

        Customer Customer(string customerId);

        Customer CustomerWithOrders(string customerId);

        void Dispose();

        bool IsSchemaValid(string schemaFile, out string schemaErrors);
    }
}