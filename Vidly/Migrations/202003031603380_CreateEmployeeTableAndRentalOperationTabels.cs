namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateEmployeeTableAndRentalOperationTabels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "RentalDetails_ID", "dbo.RentalDetails");
            DropForeignKey("dbo.Customers", "Rental_ID", "dbo.Rentals");
            DropForeignKey("dbo.Employees", "Rental_ID", "dbo.Rentals");
            DropForeignKey("dbo.Rentals", "RentalDetails_ID", "dbo.RentalDetails");
            DropIndex("dbo.Customers", new[] { "Rental_ID" });
            DropIndex("dbo.Employees", new[] { "Rental_ID" });
            DropIndex("dbo.Movies", new[] { "RentalDetails_ID" });
            DropIndex("dbo.Rentals", new[] { "RentalDetails_ID" });
            CreateIndex("dbo.Rentals", "CustomerID");
            CreateIndex("dbo.Rentals", "EmployeeID");
            CreateIndex("dbo.RentalDetails", "RentalID");
            CreateIndex("dbo.RentalDetails", "MovieID");
            AddForeignKey("dbo.Rentals", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "EmployeeID", "dbo.Employees", "ID", cascadeDelete: true);
            AddForeignKey("dbo.RentalDetails", "MovieID", "dbo.Movies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.RentalDetails", "RentalID", "dbo.Rentals", "ID", cascadeDelete: true);
            DropColumn("dbo.Customers", "Rental_ID");
            DropColumn("dbo.Employees", "Rental_ID");
            DropColumn("dbo.Movies", "RentalDetails_ID");
            DropColumn("dbo.Rentals", "RentalDetails_ID");
        }

        public override void Down()
        {
            AddColumn("dbo.Rentals", "RentalDetails_ID", c => c.Int());
            AddColumn("dbo.Movies", "RentalDetails_ID", c => c.Int());
            AddColumn("dbo.Employees", "Rental_ID", c => c.Int());
            AddColumn("dbo.Customers", "Rental_ID", c => c.Int());
            DropForeignKey("dbo.RentalDetails", "RentalID", "dbo.Rentals");
            DropForeignKey("dbo.RentalDetails", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Rentals", "CustomerID", "dbo.Customers");
            DropIndex("dbo.RentalDetails", new[] { "MovieID" });
            DropIndex("dbo.RentalDetails", new[] { "RentalID" });
            DropIndex("dbo.Rentals", new[] { "EmployeeID" });
            DropIndex("dbo.Rentals", new[] { "CustomerID" });
            CreateIndex("dbo.Rentals", "RentalDetails_ID");
            CreateIndex("dbo.Movies", "RentalDetails_ID");
            CreateIndex("dbo.Employees", "Rental_ID");
            CreateIndex("dbo.Customers", "Rental_ID");
            AddForeignKey("dbo.Rentals", "RentalDetails_ID", "dbo.RentalDetails", "ID");
            AddForeignKey("dbo.Employees", "Rental_ID", "dbo.Rentals", "ID");
            AddForeignKey("dbo.Customers", "Rental_ID", "dbo.Rentals", "ID");
            AddForeignKey("dbo.Movies", "RentalDetails_ID", "dbo.RentalDetails", "ID");
        }
    }
}
