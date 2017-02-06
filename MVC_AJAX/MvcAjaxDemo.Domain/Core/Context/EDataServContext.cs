using System.Data.Entity;
using MvcAjaxDemo.Core.Domain;
using MvcAjaxDemo.Core.Context.EntityConfiguration;

namespace MvcAjaxDemo.Core.Context
{
    public class EDataServContext : DbContext
    {
        public EDataServContext() : base("name=EDataServContext")
        {
            Database.SetInitializer<EDataServContext>(new DropCreateDatabaseIfModelChanges<EDataServContext>());
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Product> Products{ get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}
