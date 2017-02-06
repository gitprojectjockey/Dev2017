using MvcAjaxDemo.Core.Context;
using MvcAjaxDemo.Core.Repositories.Abstract;
namespace MvcAjaxDemo.Core.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        int Complete();
    }
}
