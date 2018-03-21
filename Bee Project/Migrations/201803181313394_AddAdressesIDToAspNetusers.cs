namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdressesIDToAspNetusers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AddressesID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AddressesID");
        }
    }
}
