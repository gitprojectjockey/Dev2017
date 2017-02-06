using EDataLayer.Core.DataContext;
using EDataLayer.Core.Domain;
using EDataLayer.Core.Domain.ResultEntities;
using EDataLayer.Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EDataLayer.Core.Repositories.Concrete
{
    public class ProductCatagoryRepository : Repository<ProductCatagory>, IProductCatagoryRepository
    {

        private readonly EDataServeContext _context;
        public ProductCatagoryRepository(EDataServeContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProductCatagoryWithProductResult> ProductCatagoriesWithProducts()
        {
            var joined = (from p in _context.Products
                          join pc in _context.ProductCatagories
                          on p.ProductCatagoryId equals pc.ProductCatagoryId
                          select new ProductCatagoryWithProductResult()
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName,
                              ProductDescription = p.Description,
                              Price = p.Price,
                              ProductCatagoryName = pc.CatagoryName,
                              ProductCatagoryId = pc.ProductCatagoryId
                          }).OrderBy(pc => pc.ProductCatagoryName).ToList();

            return joined;
        }

        public IEnumerable<ProductCatagoryWithProductResult> ProductCatagoryWithProducts(ProductCatagory productCatagory)
        {
            var joined = (from p in _context.Products
                          join pc in _context.ProductCatagories
                          on p.ProductCatagoryId equals pc.ProductCatagoryId
                          where pc.ProductCatagoryId == productCatagory.ProductCatagoryId
                          select new ProductCatagoryWithProductResult()
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName,
                              ProductDescription = p.Description,
                              Price = p.Price,
                              ProductCatagoryName = pc.CatagoryName,
                              ProductCatagoryId = pc.ProductCatagoryId
                          }).OrderBy(p => productCatagory.CatagoryName).ToList();

            return joined;
        }
    }
}

    

