namespace EDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 2),
                        Sequence = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Guid(nullable: false),
                        ProductCatagoryId = c.Guid(nullable: false),
                        Sequence = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.ProductCatagory", t => t.ProductCatagoryId)
                .Index(t => t.CompanyId)
                .Index(t => t.ProductCatagoryId);
            
            CreateTable(
                "dbo.ProductCatagory",
                c => new
                    {
                        ProductCatagoryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sequence = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ProductCatagoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductCatagoryId", "dbo.ProductCatagory");
            DropForeignKey("dbo.Product", "CompanyId", "dbo.Company");
            DropIndex("dbo.Product", new[] { "ProductCatagoryId" });
            DropIndex("dbo.Product", new[] { "CompanyId" });
            DropTable("dbo.ProductCatagory");
            DropTable("dbo.Product");
            DropTable("dbo.Company");
        }
    }
}
