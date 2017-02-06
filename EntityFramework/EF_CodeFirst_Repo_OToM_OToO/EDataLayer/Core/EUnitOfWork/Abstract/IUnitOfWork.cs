using EDataLayer.Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDataLayer.Core.EUnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }

        IProductRepository Products { get; }

        IProductCatagoryRepository ProductCatagories { get; }

        int Complete();
    }
}
