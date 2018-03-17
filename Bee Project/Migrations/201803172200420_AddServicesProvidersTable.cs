namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServicesProvidersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceProviders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceProviders");
        }
    }
}
