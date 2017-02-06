using EDataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDataLayer.Core.Repositories.Async.Abstract
{
    public interface IProductRepositoryAsync : IRepositoryAsync<Product>
    {
        Task<IEnumerable<Product>> ProductsByCompanyAndProductCatagoryAsync(Company company,ProductCatagory productCatagory);

        Task<bool> ProductExistsAsync(Product product);

        Task<bool> ProductRangeExistsAsync(IEnumerable<Product> products);

        Task<IEnumerable<Product>> GetProductsByRangeAsync(IEnumerable<Product> products);

        Task<IEnumerable<Product>> GetProductsByRangeAsync(IEnumerable<Guid> productIds);

        Task<Product> GetProductByNameAsync(string name);
    }
}
