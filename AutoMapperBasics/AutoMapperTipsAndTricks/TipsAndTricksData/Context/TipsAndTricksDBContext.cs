using System.Data.Entity;
using TipsAndTricksData.Entities;
using TipsAndTricksData.EntityMaps;

namespace TipsAndTricksData.Context
{
    public class TipsAndTricksDBContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public TipsAndTricksDBContext() : base("name=TipsAndTricksDBContext")
        {
            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TipsAndTricksDBContext>());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new HospitalEntityMap());
            modelBuilder.Configurations.Add(new DoctorEntityMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
