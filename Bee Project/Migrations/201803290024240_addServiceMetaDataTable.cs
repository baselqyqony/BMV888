namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServiceMetaDataTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceMetaDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        serviceID = c.Int(nullable: false),
                        metaDataID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Services", t => t.serviceID, cascadeDelete: true)
                .Index(t => t.serviceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceMetaDatas", "serviceID", "dbo.Services");
            DropIndex("dbo.ServiceMetaDatas", new[] { "serviceID" });
            DropTable("dbo.ServiceMetaDatas");
        }
    }
}
