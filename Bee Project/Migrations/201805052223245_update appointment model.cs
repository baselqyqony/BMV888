namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateappointmentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Duration", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Duration");
        }
    }
}
