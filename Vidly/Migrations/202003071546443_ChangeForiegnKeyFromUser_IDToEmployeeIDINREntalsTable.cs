namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForiegnKeyFromUser_IDToEmployeeIDINREntalsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rentals", new[] { "User_Id" });
            DropColumn("dbo.Rentals", "EmployeeID");
            RenameColumn(table: "dbo.Rentals", name: "User_Id", newName: "EmployeeID");
            AlterColumn("dbo.Rentals", "EmployeeID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Rentals", "EmployeeID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Rentals", "EmployeeID");
            AddForeignKey("dbo.Rentals", "EmployeeID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "EmployeeID", "dbo.AspNetUsers");
            DropIndex("dbo.Rentals", new[] { "EmployeeID" });
            AlterColumn("dbo.Rentals", "EmployeeID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rentals", "EmployeeID", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Rentals", name: "EmployeeID", newName: "User_Id");
            AddColumn("dbo.Rentals", "EmployeeID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rentals", "User_Id");
            AddForeignKey("dbo.Rentals", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
