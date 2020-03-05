namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteEmployeeTableAndMakeApplicationUserInstead : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Rentals", new[] { "EmployeeID" });
            AddColumn("dbo.Rentals", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rentals", "User_Id");
            AddForeignKey("dbo.Rentals", "User_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Rentals", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rentals", new[] { "User_Id" });
            DropColumn("dbo.Rentals", "User_Id");
            CreateIndex("dbo.Rentals", "EmployeeID");
            AddForeignKey("dbo.Rentals", "EmployeeID", "dbo.Employees", "ID", cascadeDelete: true);
        }
    }
}
