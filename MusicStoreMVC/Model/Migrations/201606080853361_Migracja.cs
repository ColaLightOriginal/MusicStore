namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Orders", new[] { "Cart_Id" });
            AddColumn("dbo.Orders", "PriceDecimal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Status", c => c.String());
            DropColumn("dbo.Orders", "Cart_Id");
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Cart_Id", c => c.Int());
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "PriceDecimal");
            CreateIndex("dbo.Orders", "Cart_Id");
            AddForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
