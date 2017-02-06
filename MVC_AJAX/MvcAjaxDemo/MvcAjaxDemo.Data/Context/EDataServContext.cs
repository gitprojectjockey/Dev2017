using System.Data.Entity;
using MvcAjaxDemo.Data.Core.Domain;
using MvcAjaxDemo.Data.Context.EntityConfiguration;

namespace MvcAjaxDemo.Data.Context
{
    public class EDataServContext : DbContext
    {
        public EDataServContext() : base("name=EDataServContext")
        {
            Database.SetInitializer<EDataServContext>(new DropCreateDatabaseIfModelChanges<EDataServContext>());
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}
