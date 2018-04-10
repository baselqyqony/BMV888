namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updataAppointmentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "IsBooked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "IsCancelled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "IsPostponed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Appointments", "Date");
            DropColumn("dbo.Appointments", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "IsPostponed");
            DropColumn("dbo.Appointments", "IsCancelled");
            DropColumn("dbo.Appointments", "IsBooked");
            DropColumn("dbo.Appointments", "EndTime");
            DropColumn("dbo.Appointments", "StartTime");
            DropColumn("dbo.Appointments", "EndDate");
            DropColumn("dbo.Appointments", "StartDate");
        }
    }
}
