namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReturnDateColumnTORentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "ReturnDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "ReturnDate");
        }
    }
}
