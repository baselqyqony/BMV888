namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknown : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Addresses", "CityID");
            AddForeignKey("dbo.Addresses", "CityID", "dbo.Cities", "ID", cascadeDelete: true);
            DropColumn("dbo.ServiceProviders", "AddressID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceProviders", "AddressID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Addresses", "CityID", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "CityID" });
        }
    }
}
