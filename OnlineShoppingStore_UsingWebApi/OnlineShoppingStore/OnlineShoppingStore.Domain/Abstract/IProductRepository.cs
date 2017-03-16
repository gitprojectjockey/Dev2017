using OnlineShoppingStore.Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace OnlineShoppingStore.Domain.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Products();

        Task<IEnumerable<Product>> Products(string key);

        Task<Product> SaveProduct(Product product, string email, string password);

        Task<Product> DeleteProduct(int productId, string email, string password);

        IEnumerable<Product> ProductsSynchronous();

        IEnumerable<Product> ProductsSynchronous(string key);

        Product SaveProductSyncronous(Product product, string email, string password);

        Product DeleteProductSyncronous(int productId, string email, string password);
    }
}
