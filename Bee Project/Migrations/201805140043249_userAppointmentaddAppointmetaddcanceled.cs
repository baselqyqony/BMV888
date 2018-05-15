namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAppointmentaddAppointmetaddcanceled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAppointments", "canceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAppointments", "canceled");
        }
    }
}
