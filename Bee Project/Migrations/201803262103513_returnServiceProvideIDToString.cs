namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class returnServiceProvideIDToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceProviders", "UserID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProviders", "UserID", c => c.Int(nullable: false));
        }
    }
}
