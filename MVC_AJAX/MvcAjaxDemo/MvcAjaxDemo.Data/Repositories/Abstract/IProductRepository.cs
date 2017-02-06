using MvcAjaxDemo.Data.Core.Domain;
using System.Collections.Generic;

namespace MvcAjaxDemo.Data.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetMostExpensiveProducts(int count);

        IEnumerable<Product> GetLeastExpensiveProducts(int count);

        IEnumerable<Product> GetProductsPaged(int pageIndex, int pageSize);
    }
}
