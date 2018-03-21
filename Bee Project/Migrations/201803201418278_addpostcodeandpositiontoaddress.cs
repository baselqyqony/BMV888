namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpostcodeandpositiontoaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "PotalCode", c => c.String());
            AddColumn("dbo.Addresses", "longitude", c => c.String());
            AddColumn("dbo.Addresses", "ultitude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "ultitude");
            DropColumn("dbo.Addresses", "longitude");
            DropColumn("dbo.Addresses", "PotalCode");
        }
    }
}
