using System;
using System.Collections.Generic;
using OnlineShoppingService.Domain.Entities;

namespace OnlineShoppingService.Domain.Abstract
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> Products { get; }
        Product SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
