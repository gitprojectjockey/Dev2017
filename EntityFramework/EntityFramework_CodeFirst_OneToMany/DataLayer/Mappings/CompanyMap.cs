
using DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.Mappings
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            //Primary Key
            ToTable("Company")
                .HasKey<int>(c => c.Id)
                .Property<int>(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Properties
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);


            Property(c => c.State)
                .IsRequired()
                .HasMaxLength(2);

        }
    }
}
