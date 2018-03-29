namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserActvationsTb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserActivations", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserActivations", "UserID");
        }
    }
}
