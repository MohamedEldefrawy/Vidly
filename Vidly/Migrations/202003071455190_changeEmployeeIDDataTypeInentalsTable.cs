namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeEmployeeIDDataTypeInentalsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "EmployeeID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rentals", "RentDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Rentals", "ReturnDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.RentalDetails", "unitPrice", c => c.Decimal(nullable: false, precision: 9, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RentalDetails", "unitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Rentals", "ReturnDate", c => c.DateTime());
            AlterColumn("dbo.Rentals", "RentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rentals", "EmployeeID", c => c.Int(nullable: false));
        }
    }
}
