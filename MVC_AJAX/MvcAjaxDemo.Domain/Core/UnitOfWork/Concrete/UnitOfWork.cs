using System;
using MvcAjaxDemo.Core.Repositories.Abstract;
using MvcAjaxDemo.Core.UnitOfWork.Abstract;
using MvcAjaxDemo.Core.Context;
using MvcAjaxDemo.Core.Repositories.Concrete;

namespace MvcAjaxDemo.Core.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EDataServContext _context;

        public UnitOfWork(EDataServContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
        }
        public IProductRepository Products{ get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
