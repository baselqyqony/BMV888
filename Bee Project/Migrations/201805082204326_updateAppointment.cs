namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAppointment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "UserID", c => c.Int(nullable: false));
        }
    }
}
