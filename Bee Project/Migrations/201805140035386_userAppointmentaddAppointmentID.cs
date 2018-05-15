namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAppointmentaddAppointmentID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAppointments", "AppointmentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAppointments", "AppointmentID");
        }
    }
}
