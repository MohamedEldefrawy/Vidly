namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name])
     VALUES
           ('3e84a833-b209-451b-88e9-7257d5eccfff',
           'CanManageMovies');
INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[Email]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEndDateUtc]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName])
     VALUES
           ('7c9e6555-aa5b-422c-a2fb-653b5bb6b26a'
           ,'admin@vidly.com'
           ,0
           ,'AGMdnCoR3F0wbyXkDVbTOFLG4KoJKHXvbx5ev0KYB/JVNcDfA3a8XtsSGUXZRFfQBQ=='
           ,'af62747d-4775-4dd3-8778-a1036729d763'
           ,'01153779995'
           ,0
           ,0
           ,NULL
           ,1
           ,0
           ,'admin@vidly.com');
INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
     VALUES
           ('7c9e6555-aa5b-422c-a2fb-653b5bb6b26a'
           ,'3e84a833-b209-451b-88e9-7257d5eccfff')

"
            );
        }

        public override void Down()
        {
        }
    }
}
