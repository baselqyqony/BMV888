namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryIDToCitieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "CountryID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "CountryID");
        }
    }
}
