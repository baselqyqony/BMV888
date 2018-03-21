namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuildingToAddressesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Building", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "Building");
        }
    }
}
