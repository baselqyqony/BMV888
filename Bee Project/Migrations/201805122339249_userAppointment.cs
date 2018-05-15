namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAppointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAppointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        startTime = c.DateTime(nullable: false),
                        endTime = c.DateTime(nullable: false),
                        appointmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAppointments");
        }
    }
}
