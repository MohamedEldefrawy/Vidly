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
           (<Id, nvarchar(128),>
           ,<Name, nvarchar(256),>);
INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
     VALUES
           (<UserId, nvarchar(128),>
           ,<RoleId, nvarchar(128),>);
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
           (<Id, nvarchar(128),>
           ,<Email, nvarchar(256),>
           ,<EmailConfirmed, bit,>
           ,<PasswordHash, nvarchar(max),>
           ,<SecurityStamp, nvarchar(max),>
           ,<PhoneNumber, nvarchar(max),>
           ,<PhoneNumberConfirmed, bit,>
           ,<TwoFactorEnabled, bit,>
           ,<LockoutEndDateUtc, datetime,>
           ,<LockoutEnabled, bit,>
           ,<AccessFailedCount, int,>
           ,<UserName, nvarchar(256),>)
"
            );
        }

        public override void Down()
        {
        }
    }
}
