namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatememmberShipTypeForiegnKeyToCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MemberShipType_Id", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipType_Id" });
            RenameColumn(table: "dbo.Customers", name: "MemberShipType_Id", newName: "MemberShipID");
            AlterColumn("dbo.Customers", "MemberShipID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipID");
            AddForeignKey("dbo.Customers", "MemberShipID", "dbo.MemberShipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipID", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipID" });
            AlterColumn("dbo.Customers", "MemberShipID", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MemberShipID", newName: "MemberShipType_Id");
            CreateIndex("dbo.Customers", "MemberShipType_Id");
            AddForeignKey("dbo.Customers", "MemberShipType_Id", "dbo.MemberShipTypes", "Id");
        }
    }
}
