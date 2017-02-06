
namespace EDataLayer.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Core.Domain;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<Core.DataContext.EDataServeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Core.DataContext.EDataServeContext context)
        {

            //Delete all the seed data before adding new seed data
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");

            var companies = new List<Company>()
             {
                 new Company { CompanyName = "XEROX", State = "CO" },
                 new Company { CompanyName = "RMFN", State = "MI" },
                 new Company { CompanyName = "E and V Medical Suppies", State = "MA" },
                 new Company { CompanyName = "Supply All Inc.", State = "OH" }
             };

            foreach (var company in companies)
                context.Companies.AddOrUpdate(c => c.CompanyName, company);



            var productCatagories = new List<ProductCatagory>()
              {
                new ProductCatagory() { CatagoryName = "MEDICAL" },
                new ProductCatagory() { CatagoryName = "CULINARY" },
                new ProductCatagory() { CatagoryName = "OFFICE" }
              };

            foreach (var productCatagory in productCatagories)
                context.ProductCatagories.AddOrUpdate(pc => pc.CatagoryName, productCatagory);

            //save changes here so when creating new pro
            context.SaveChanges();


            context.Products.AddOrUpdate(
                new Product()
                {
                    ProductName = "Protective Medical Mask",
                    Description = "Protective Mask For Medical Use",
                    CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "E and V Medical Suppies").CompanyId,
                    ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName== "MEDICAL").ProductCatagoryId,
                    Price = 34.78m
                },
                new Product()
                {
                    ProductName = "IV Tubing",
                    Description = "200 ft of high strength rubber tubing",
                    CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "E and V Medical Suppies").CompanyId,
                    ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "MEDICAL").ProductCatagoryId,
                    Price = 109.00m
                },
                 new Product()
                 {
                     ProductName = "Pork Tenderloin",
                     Description = "Box of 20 3lb pork tenerloins",
                     CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "RMFN").CompanyId,
                     ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "CULINARY").ProductCatagoryId,
                     Price = 344.78m
                 },
                new Product()
                {
                    ProductName = "Beef Tenderloin",
                    Description = "Box of 20 4lb beef tenerloins",
                    CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "RMFN").CompanyId,
                    ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "CULINARY").ProductCatagoryId,
                    Price = 566.22m
                },
                 new Product()
                 {
                     ProductName = "Duplex Scanner",
                     Description = "High speed black and white dual side scanner",
                     CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "XEROX").CompanyId,
                     ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "OFFICE").ProductCatagoryId,
                     Price = 10169.29m
                 },
                  new Product()
                  {
                      ProductName = "Duplex Printer",
                      Description = "High speed black and white dual side printer",
                      CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "XEROX").CompanyId,
                      ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "OFFICE").ProductCatagoryId,
                      Price = 10100.78m
                  },
                   new Product()
                   {
                       ProductName = "Printer Paper",
                       Description = "Printer Paper by the pallet",
                       CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "Supply All Inc.").CompanyId,
                       ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "OFFICE").ProductCatagoryId,
                       Price = 999.67m
                   },
                    new Product()
                    {
                        ProductName = "Printer Ink",
                        Description = "Printer Inc by the pallet",
                        CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "Supply All Inc.").CompanyId,
                        ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "OFFICE").ProductCatagoryId,
                        Price = 30000.22m
                    },
                     new Product()
                     {
                         ProductName = "Paper Towels",
                         Description = "Paper towels by the pallet",
                         CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "Supply All Inc.").CompanyId,
                         ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "CULINARY").ProductCatagoryId,
                         Price = 200.89m
                     },
                     new Product()
                     {
                         ProductName = "Protective kithen hot gloves",
                         Description = "Kithen hot gloves by the pallet",
                         CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "Supply All Inc.").CompanyId,
                         ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "CULINARY").ProductCatagoryId,
                         Price = 303.72m
                     },
                     new Product()
                     {
                         ProductName = "Kithen Stove Cleaner",
                         Description = "High strength kithen stove cleaner by the pallet",
                         CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "Supply All Inc.").CompanyId,
                         ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "CULINARY").ProductCatagoryId,
                         Price = 623.72m
                     },
                     new Product()
                     {
                         ProductName = "Medical Floor Cleaner",
                         Description = "High strength medical floor cleaner by the pallet",
                         CompanyId = context.Companies.FirstOrDefault(c => c.CompanyName == "Supply All Inc.").CompanyId,
                         ProductCatagoryId = context.ProductCatagories.FirstOrDefault(pc => pc.CatagoryName == "MEDICAL").ProductCatagoryId,
                         Price = 1623.88m
                     }
             );
        }
    }
}
