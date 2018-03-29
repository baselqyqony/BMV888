namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserActvationsTb2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserActivations", "ActivationCode", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserActivations", "ActivationCode", c => c.String());
        }
    }
}
