namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaddressesIDtocustomeraddresses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Addresses_ID", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "Addresses_ID" });
            AddColumn("dbo.Customers", "Addresses", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "Addresses_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Addresses_ID", c => c.Int());
            DropColumn("dbo.Customers", "Addresses");
            CreateIndex("dbo.Customers", "Addresses_ID");
            AddForeignKey("dbo.Customers", "Addresses_ID", "dbo.Addresses", "ID");
        }
    }
}
