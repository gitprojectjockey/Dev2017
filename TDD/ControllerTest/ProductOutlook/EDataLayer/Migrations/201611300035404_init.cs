namespace EDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Guid(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Guid(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Guid(nullable: false),
                        ProductCatagoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.ProductCatagory", t => t.ProductCatagoryId)
                .Index(t => new { t.ProductName, t.CompanyId, t.ProductCatagoryId }, unique: true, name: "IX_Product");
            
            CreateTable(
                "dbo.ProductCatagory",
                c => new
                    {
                        ProductCatagoryId = c.Guid(nullable: false, identity: true),
                        CatagoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProductCatagoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductCatagoryId", "dbo.ProductCatagory");
            DropForeignKey("dbo.Product", "CompanyId", "dbo.Company");
            DropIndex("dbo.Product", "IX_Product");
            DropTable("dbo.ProductCatagory");
            DropTable("dbo.Product");
            DropTable("dbo.Company");
        }
    }
}
