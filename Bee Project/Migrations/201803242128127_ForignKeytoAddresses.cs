namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForignKeytoAddresses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Addresses_ID", c => c.Int());
            CreateIndex("dbo.Customers", "Addresses_ID");
            CreateIndex("dbo.ServiceProviders", "AddressesID");
            AddForeignKey("dbo.Customers", "Addresses_ID", "dbo.Addresses", "ID");
            AddForeignKey("dbo.ServiceProviders", "AddressesID", "dbo.Addresses", "ID", cascadeDelete: true);
            DropColumn("dbo.Customers", "AddressesID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "AddressesID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ServiceProviders", "AddressesID", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "Addresses_ID", "dbo.Addresses");
            DropIndex("dbo.ServiceProviders", new[] { "AddressesID" });
            DropIndex("dbo.Customers", new[] { "Addresses_ID" });
            DropColumn("dbo.Customers", "Addresses_ID");
        }
    }
}
