namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserActvationsTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActivations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActivationCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserActivations");
        }
    }
}
