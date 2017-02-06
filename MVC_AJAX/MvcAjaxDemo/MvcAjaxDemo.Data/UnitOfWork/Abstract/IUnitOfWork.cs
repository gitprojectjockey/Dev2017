using MvcAjaxDemo.Data.Repositories.Abstract;

namespace MvcAjaxDemo.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        int Complete();
    }
}
