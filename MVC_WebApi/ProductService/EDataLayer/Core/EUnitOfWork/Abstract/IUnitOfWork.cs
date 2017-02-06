using EDataLayer.Core.Repositories.Abstract;
using System;

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
