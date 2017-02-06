using DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            //Primary Key
            ToTable("Product")
                .HasKey<int>(p => p.Id)
                .Property<int>(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Properties
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);

            Property(p => p.Catagory)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Price)
                .IsRequired();

            //One Company to Many Products Relationship
            HasRequired(p => p.Company)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CompanyId)
                .WillCascadeOnDelete(false);
        }
    }
}
