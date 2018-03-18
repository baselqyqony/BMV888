namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteappointmentcolumninServicestable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "AppointmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "AppointmentID", c => c.Int(nullable: false));
        }
    }
}
