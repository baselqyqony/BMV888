namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServicesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        AppointmentID = c.Int(nullable: false),
                        AdressesID = c.Int(nullable: false),
                        ServiceTypeID = c.Int(nullable: false),
                        ServiceProviderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
        }
    }
}
