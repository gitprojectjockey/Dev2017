using EDataLayer.Core.Domain;
using System;
using System.Collections.Generic;

namespace EDataLayer.Core.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> ProductsByCompanyAndProductCatagory(Company company,ProductCatagory productCatagory);

        bool ProductExists(Product product);

        bool ProductRangeExists(IEnumerable<Product> products);

        IEnumerable<Product> GetProductsByRange(IEnumerable<Product> products);

        IEnumerable<Product> GetProductsByRange(IEnumerable<Guid> productIds);

        Product GetProductByName(string name);
    }
}
