namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSerachLogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        selectedServiceType = c.Int(nullable: false),
                        serviceTypes = c.Int(nullable: false),
                        selectedCity = c.Int(nullable: false),
                        selectedCountry = c.Int(nullable: false),
                        longitude = c.String(),
                        altitude = c.String(),
                        isNearBy = c.Boolean(nullable: false),
                        userID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SearchMetaDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MetaDataID = c.Int(nullable: false),
                        SearchLogsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SearchLogs", t => t.SearchLogsID, cascadeDelete: true)
                .Index(t => t.SearchLogsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SearchMetaDatas", "SearchLogsID", "dbo.SearchLogs");
            DropIndex("dbo.SearchMetaDatas", new[] { "SearchLogsID" });
            DropTable("dbo.SearchMetaDatas");
            DropTable("dbo.SearchLogs");
        }
    }
}
