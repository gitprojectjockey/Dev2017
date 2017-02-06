
using MvcAjaxDemo.Core.Repositories.Abstract;
using MvcAjaxDemo.Core.Context;
using MvcAjaxDemo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcAjaxDemo.Core.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(EDataServContext context) 
            : base(context) {}

        public IEnumerable<Product> GetProductsPaged(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetTopSellingProducts(int count)
        {
            return EDataServContext.Products.OrderByDescending(p => p.Price).Take(count).ToList();
        }

        private EDataServContext EDataServContext
        {
            get { return _context as EDataServContext; }
        }
    }
}
