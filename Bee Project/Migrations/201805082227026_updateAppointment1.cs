namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAppointment1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "IsAvailable");
            DropColumn("dbo.Appointments", "IsBooked");
            DropColumn("dbo.Appointments", "IsCancelled");
            DropColumn("dbo.Appointments", "IsPostponed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "IsPostponed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "IsCancelled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "IsBooked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "IsAvailable", c => c.Boolean(nullable: false));
        }
    }
}
