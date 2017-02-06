using System.Data.Entity.ModelConfiguration;
using EDataLayer.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EDataLayer.Core.DataContext.ModelMaps
{
    public class ProductCatagoryMap : EntityTypeConfiguration<ProductCatagory>
    {
        public ProductCatagoryMap()
        {
            //Primary Key
            ToTable("ProductCatagory")
              .HasKey(pc => pc.ProductCatagoryId)
              .Property(pc => pc.ProductCatagoryId)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Properties
            Property(pc => pc.CatagoryName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
