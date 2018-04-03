namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmerrage : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.UserActivations",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            UserID = c.String(),
            //            ActivationCode = c.Guid(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //AddColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
            //AddColumn("dbo.Customers", "PhoneNumber", c => c.String());
            //AddColumn("dbo.Customers", "AddressesID", c => c.Int(nullable: false));
            //AddColumn("dbo.ServiceProviders", "UserName", c => c.String());
            //AddColumn("dbo.ServiceProviders", "PhoneNumber", c => c.String());
            //AddColumn("dbo.ServiceProviders", "AddressesID", c => c.Int(nullable: false));
            //DropColumn("dbo.ServiceProviders", "AddressID");
            //DropColumn("dbo.AspNetUsers", "AddressesID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AddressesID", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceProviders", "AddressID", c => c.Int(nullable: false));
            DropColumn("dbo.ServiceProviders", "AddressesID");
            DropColumn("dbo.ServiceProviders", "PhoneNumber");
            DropColumn("dbo.ServiceProviders", "UserName");
            DropColumn("dbo.Customers", "AddressesID");
            DropColumn("dbo.Customers", "PhoneNumber");
            DropColumn("dbo.Customers", "UserName");
            DropTable("dbo.UserActivations");
        }
    }
}
