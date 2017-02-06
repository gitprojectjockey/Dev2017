using System.Data.Entity;
using DataLayer.Mappings;

namespace DataLayer.Models
{
    public class DataLayerContext : DbContext
    {
        public DataLayerContext() : base("name=DataLayerContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayerContext>());
            Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Configurations.Add(new CompanyMap());

            modelBuilder.Configurations.Add(new ProductMap());

            modelBuilder.Entity<Product>()

                    .Property(p => p.Price)
                    .HasPrecision(16, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
