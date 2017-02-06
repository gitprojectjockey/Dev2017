namespace EDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNameToFullName : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product", "IX_Product");
            AddColumn("dbo.Company", "CompanyName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Product", "ProductName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ProductCatagory", "CatagoryName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Product", new[] { "ProductName", "CompanyId", "ProductCatagoryId" }, unique: true, name: "IX_Product");
            DropColumn("dbo.Company", "Name");
            DropColumn("dbo.Product", "Name");
            DropColumn("dbo.ProductCatagory", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCatagory", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Company", "Name", c => c.String(nullable: false, maxLength: 50));
            DropIndex("dbo.Product", "IX_Product");
            DropColumn("dbo.ProductCatagory", "CatagoryName");
            DropColumn("dbo.Product", "ProductName");
            DropColumn("dbo.Company", "CompanyName");
            CreateIndex("dbo.Product", new[] { "Name", "CompanyId", "ProductCatagoryId" }, unique: true, name: "IX_Product");
        }
    }
}
