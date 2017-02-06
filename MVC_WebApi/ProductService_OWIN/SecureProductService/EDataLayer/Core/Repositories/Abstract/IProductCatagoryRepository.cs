using EDataLayer.Core.Domain;
using EDataLayer.Core.Domain.ResultEntities;
using System;
using System.Collections.Generic;

namespace EDataLayer.Core.Repositories.Abstract
{
    public interface IProductCatagoryRepository : IRepository<ProductCatagory>
    {
        IEnumerable<ProductCatagoryWithProductResult> ProductCatagoriesWithProducts();

        IEnumerable<ProductCatagoryWithProductResult> ProductCatagoryWithProducts(ProductCatagory productCatagory);

        bool ProductCatagoryExists(ProductCatagory productCatagory);

        bool ProductCatagoryRangeExists(IEnumerable<ProductCatagory> ProductCatagories);
    }
}
