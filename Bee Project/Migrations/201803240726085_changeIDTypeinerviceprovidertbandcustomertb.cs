namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIDTypeinerviceprovidertbandcustomertb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserID", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "UserID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProviders", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "UserID", c => c.Int(nullable: false));
        }
    }
}
