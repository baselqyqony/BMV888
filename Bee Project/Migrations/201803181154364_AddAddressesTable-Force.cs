namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressesTableForce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        Ditricit = c.String(),
                        Street = c.String(),
                        Floornumber = c.Int(nullable: false),
                        DoorNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Addresses");
        }
    }
}
