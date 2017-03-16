using System.ComponentModel.DataAnnotations.Schema;
using TipsAndTricksData.Entities;
using System.Data.Entity.ModelConfiguration;
namespace TipsAndTricksData.EntityMaps
{
    public class DoctorEntityMap : EntityTypeConfiguration<Doctor>
    {
        public DoctorEntityMap()
        {
            ToTable("Doctors")
              .HasKey(d => d.Id)
              .Property(d => d.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Title)
              .IsRequired()
              .HasMaxLength(50);

            Property(d => d.FirstName)
               .IsRequired()
               .HasMaxLength(50);

            Property(d => d.LastName)
               .IsRequired()
               .HasMaxLength(50);

            Property<int>(d => d.HospitalId)
               .IsRequired();

            //Many doctors to one hospital
            HasRequired(d => d.Hospital)
                .WithMany(d => d.Doctors)
                .HasForeignKey<int>(d => d.HospitalId)
                .WillCascadeOnDelete(false);
        }
    }
}
