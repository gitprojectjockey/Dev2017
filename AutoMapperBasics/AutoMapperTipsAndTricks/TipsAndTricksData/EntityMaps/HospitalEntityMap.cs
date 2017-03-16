using TipsAndTricksData.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TipsAndTricksData.EntityMaps
{
    public class HospitalEntityMap : EntityTypeConfiguration<Hospital>
    {
        public HospitalEntityMap()
        {
            ToTable("Hospital")
              .HasKey(d => d.Id)
              .Property(d => d.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(h => h.Name)
             .IsRequired()
             .HasMaxLength(50);

            Property(h => h.Street)
               .IsRequired()
               .HasMaxLength(100);

            Property(h => h.City)
               .IsRequired()
               .HasMaxLength(50);

            Property(h => h.State)
               .IsRequired()
               .HasMaxLength(20);

            Property(h => h.ZipCode)
               .IsRequired()
               .HasMaxLength(10);
        }

    }
}
