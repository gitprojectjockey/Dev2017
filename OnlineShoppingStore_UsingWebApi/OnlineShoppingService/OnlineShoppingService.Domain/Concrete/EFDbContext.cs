using System;
using System.Data.Entity;
using OnlineShoppingService.Domain.Entities;
using System.Collections.Generic;

namespace OnlineShoppingService.Domain.Concrete
{
    public sealed class EFDbContext : DbContext, Abstract.IEFDbContext
    {
        public DbSet<Product> GetProducts { get; set; }
        public DbSet<User> GetUsers{get; set;}
        public DbSet<UserRole> GetUserRoles { get; set; }
        public void AddProduct(Product product)
        {
            this.GetProducts.Add(product);
            this.SaveChanges();
        }
        public void SaveProductChanges()
        {
            this.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            this.GetProducts.Remove(product);
            this.SaveChanges();
        }
        public Product FindProduct(int id)
        {
            return this.GetProducts.Find(id);
        }

        public IEnumerable<UserRole> UserRoles()
        {
            return this.GetUserRoles.AsNoTracking();
        }
    }
}
