namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeServiceMetaDataFromService : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "serviceMetaData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "serviceMetaData", c => c.String());
        }
    }
}
