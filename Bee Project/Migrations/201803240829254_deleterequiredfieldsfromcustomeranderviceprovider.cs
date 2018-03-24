namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleterequiredfieldsfromcustomeranderviceprovider : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceProviders", "CompanyName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProviders", "CompanyName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
