using EDataLayer.Core.Repositories.Async.Abstract;
using System;
using System.Threading.Tasks;

namespace EDataLayer.Core.EUnitOfWork.Async.Abstract
{
    public interface IUnitOfWorkAsync : IDisposable
    {
        IProductRepositoryAsync Products { get; }
        Task<int> CompleteAsync();
    }
}
