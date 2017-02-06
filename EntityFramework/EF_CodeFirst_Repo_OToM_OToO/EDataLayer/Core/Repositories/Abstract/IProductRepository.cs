using EDataLayer.Core.Domain;
using System;
using System.Collections.Generic;

namespace EDataLayer.Core.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> ProductsByCompanyAndProductCatagory(Company company,ProductCatagory productCatagory);
    }
}
