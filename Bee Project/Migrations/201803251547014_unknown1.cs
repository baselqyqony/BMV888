namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknown1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "CityID", "dbo.Cities");
            DropForeignKey("dbo.ServiceProviders", "AddressesID", "dbo.Addresses");
            DropIndex("dbo.Addresses", new[] { "CityID" });
            DropIndex("dbo.ServiceProviders", new[] { "AddressesID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.ServiceProviders", "AddressesID");
            CreateIndex("dbo.Addresses", "CityID");
            AddForeignKey("dbo.ServiceProviders", "AddressesID", "dbo.Addresses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "CityID", "dbo.Cities", "ID", cascadeDelete: true);
        }
    }
}
