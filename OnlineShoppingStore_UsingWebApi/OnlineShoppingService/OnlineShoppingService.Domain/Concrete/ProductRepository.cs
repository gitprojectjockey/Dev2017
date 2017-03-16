using System;
using System.Collections.Generic;
using OnlineShoppingService.Domain.Entities;

namespace OnlineShoppingService.Domain.Concrete
{
    public class ProductRepository : Abstract.IProductRepository
    {
        private  Abstract.IEFDbContext _efDatabaseContext;

        public ProductRepository(Abstract.IEFDbContext context)
        {
            _efDatabaseContext = context;
        }

        public IEnumerable<Product> Products
        {
            get
            {
                try
                {
                    return _efDatabaseContext.GetProducts;
                }
                catch
                {
                    throw;
                }
            }
        }

        public Product SaveProduct(Product product)
        {
            try
            {
                Product dbProduct = null;
                if (product.ProductId == 0)
                {
                    _efDatabaseContext.GetProducts.Add(product);
                }
                else
                {
                     dbProduct = _efDatabaseContext.FindProduct(product.ProductId);
                    if (dbProduct == null)
                    {
                        throw new ArgumentNullException();
                    }
                    else
                    {
                        dbProduct.Name = product.Name;
                        dbProduct.Description = product.Description;
                        dbProduct.Price = product.Price;
                        dbProduct.Category = product.Category;
                    }
                }

                _efDatabaseContext.SaveProductChanges();
                return product;
            }
            catch
            {
                throw;
            }
        }

        public Product DeleteProduct(int productId)
        {
            try
            {
                Product dbProduct = _efDatabaseContext.FindProduct(productId);
                if (dbProduct == null)
                {
                    throw new KeyNotFoundException();
                }
                else
                {
                    _efDatabaseContext.DeleteProduct(dbProduct);
                    _efDatabaseContext.SaveProductChanges();
                }
                return dbProduct;
            }
            catch
            {
                throw;
            }
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
                if (_efDatabaseContext != null)
                {
                    _efDatabaseContext.Dispose();
                    _efDatabaseContext = null;
                }
            }
        }
    }
}



