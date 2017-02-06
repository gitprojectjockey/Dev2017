using EDataLayer.Core.DataContext.ModelMaps;
using EDataLayer.Core.Domain;
using System.Data.Entity;

namespace EDataLayer.Core.DataContext
{
    public class EDataServeContext : DbContext
    {
        public EDataServeContext() : base("name=EDataServeContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EDataServeContext>());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
           
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCatagory> ProductCatagories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductCatagoryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
