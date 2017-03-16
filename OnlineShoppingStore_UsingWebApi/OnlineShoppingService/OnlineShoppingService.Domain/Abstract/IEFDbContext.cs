using System.Data.Entity;
using OnlineShoppingService.Domain.Entities;
using System.Collections.Generic;

namespace OnlineShoppingService.Domain.Abstract
{
    public interface IEFDbContext
    {
        void AddProduct(Product product);
        void SaveProductChanges();
        void DeleteProduct(Product product);
        Product FindProduct(int id);
        IEnumerable<UserRole> UserRoles();
        void Dispose();
        DbSet<Product> GetProducts { get; set; }
        DbSet<UserRole> GetUserRoles { get; set; }
        DbSet<User> GetUsers { get; set; }
    }
}