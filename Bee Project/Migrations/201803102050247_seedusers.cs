namespace Bee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@" 
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8ec14c40-6ff8-43c7-b7bc-8a9534ef0fc7', N'mhmad.sabha89@gmail.com', 0, N'AD/F+OZ/Aeyt286/+CZaIBcj/9UvbCf8KusIeYBmgPMduoIXz6TVnhPe+seE7OjKaQ==', N'019da5a6-8cb1-45ec-b8ca-8c11a880fddd', NULL, 0, 0, NULL, 1, 0, N'mhmad.sabha89@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fb47f0d6-7a89-42a9-9772-dd5e6fde6d5d', N'manager.sabha@gmail.com', 0, N'AADNbA/NAJnVeoGHIcx12tTRMEmSWgaV/WlRuSdjO/ygUnNo0uGl9jJlTqk2CurxPg==', N'ca99109b-e5b6-4b2d-8dd2-c49698c3ea9d', NULL, 0, 0, NULL, 1, 0, N'manager.sabha@gmail.com')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb47f0d6-7a89-42a9-9772-dd5e6fde6d5d', N'fa9c060b-54f1-4e89-86c9-673125334c85')


");
        }
        
        public override void Down()
        {
        }
    }
}
