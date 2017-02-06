using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcAjaxDemo.Core.Domain;

namespace MvcAjaxDemo.Core.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetTopSellingProducts(int count);

        IEnumerable<Product> GetProductsPaged(int pageIndex, int pageSize);
    }
}
