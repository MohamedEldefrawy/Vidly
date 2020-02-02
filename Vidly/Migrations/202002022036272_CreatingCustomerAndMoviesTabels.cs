namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingCustomerAndMoviesTabels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSubscribedToNewsetter = c.Boolean(nullable: false),
                        MemberShipID = c.Byte(nullable: false),
                        MemberShipType_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MemberShipTypes", t => t.MemberShipType_Id)
                .Index(t => t.MemberShipType_Id);
            
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipType_Id", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipType_Id" });
            DropTable("dbo.Movies");
            DropTable("dbo.MemberShipTypes");
            DropTable("dbo.Customers");
        }
    }
}
