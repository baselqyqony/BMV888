namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAppointmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Sat", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "Sun", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "Mon", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "Tue", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "Wed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "Thu", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "Fri", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Fri");
            DropColumn("dbo.Appointments", "Thu");
            DropColumn("dbo.Appointments", "Wed");
            DropColumn("dbo.Appointments", "Tue");
            DropColumn("dbo.Appointments", "Mon");
            DropColumn("dbo.Appointments", "Sun");
            DropColumn("dbo.Appointments", "Sat");
        }
    }
}
