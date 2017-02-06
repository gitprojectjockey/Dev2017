using System.Collections.Generic;
using EDataLayer.Core.Domain;
using EDataLayer.Core.Repositories.Abstract;
using EDataLayer.Core.DataContext;
using System.Linq;
using System;

namespace EDataLayer.Core.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly EDataServeContext _context;
        public ProductRepository(EDataServeContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> ProductsByCompanyAndProductCatagory(Company company, ProductCatagory catagory)
        {
            return _context.Products
                .Where(p => p.CompanyId == company.CompanyId && p.ProductCatagoryId == catagory.ProductCatagoryId)
                .OrderBy(p => p.ProductName)
                .ToList();
        }
    }
}
