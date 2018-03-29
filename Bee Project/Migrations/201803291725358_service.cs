namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class service : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Service_ID", "dbo.Services");
            DropForeignKey("dbo.ServiceProviders", "Service_ID", "dbo.Services");
            DropForeignKey("dbo.ServiceTypes", "Service_ID", "dbo.Services");
            DropIndex("dbo.Addresses", new[] { "Service_ID" });
            DropIndex("dbo.ServiceProviders", new[] { "Service_ID" });
            DropIndex("dbo.ServiceTypes", new[] { "Service_ID" });
            DropColumn("dbo.Addresses", "Service_ID");
            DropColumn("dbo.ServiceProviders", "Service_ID");
            DropColumn("dbo.ServiceTypes", "Service_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceTypes", "Service_ID", c => c.Int());
            AddColumn("dbo.ServiceProviders", "Service_ID", c => c.Int());
            AddColumn("dbo.Addresses", "Service_ID", c => c.Int());
            CreateIndex("dbo.ServiceTypes", "Service_ID");
            CreateIndex("dbo.ServiceProviders", "Service_ID");
            CreateIndex("dbo.Addresses", "Service_ID");
            AddForeignKey("dbo.ServiceTypes", "Service_ID", "dbo.Services", "ID");
            AddForeignKey("dbo.ServiceProviders", "Service_ID", "dbo.Services", "ID");
            AddForeignKey("dbo.Addresses", "Service_ID", "dbo.Services", "ID");
        }
    }
}
