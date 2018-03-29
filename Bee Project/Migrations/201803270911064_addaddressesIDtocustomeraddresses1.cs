namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaddressesIDtocustomeraddresses1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AddressesID", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "Addresses");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Addresses", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "AddressesID");
        }
    }
}
