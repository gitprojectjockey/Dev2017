using MvcAjaxDemo.Data.Context;
using MvcAjaxDemo.Data.Core.Domain;
using MvcAjaxDemo.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MvcAjaxDemo.Data.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EDataServContext context)
            : base(context) { }

        public IEnumerable<Product> GetProductsPaged(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetMostExpensiveProducts(int count)
        {
            return EDataServContext.Products.OrderByDescending(p => p.Price).Take(count).ToList();
        }

        public IEnumerable<Product> GetLeastExpensiveProducts(int count)
        {
            return EDataServContext.Products.OrderBy(p => p.Price).Take(count).ToList();
        }

        private EDataServContext EDataServContext
        {
            get { return _context as EDataServContext; }
        }
    }
}
