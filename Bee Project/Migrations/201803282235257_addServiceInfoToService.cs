namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServiceInfoToService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "serviceInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "serviceInfo");
        }
    }
}
