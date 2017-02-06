namespace EDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewProductCompositeKey : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product", "IX_Product");
            CreateIndex("dbo.Product", new[] { "Name", "CompanyId", "ProductCatagoryId" }, unique: true, name: "IX_Product");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", "IX_Product");
            CreateIndex("dbo.Product", new[] { "Name", "CompanyId", "ProductCatagoryId" }, name: "IX_Product");
        }
    }
}
