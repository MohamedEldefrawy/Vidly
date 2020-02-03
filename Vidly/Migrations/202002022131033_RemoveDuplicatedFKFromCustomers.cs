namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDuplicatedFKFromCustomers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "MemberShipID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemberShipID", c => c.Byte(nullable: false));
        }
    }
}
