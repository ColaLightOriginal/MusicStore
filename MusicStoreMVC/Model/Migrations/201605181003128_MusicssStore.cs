namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MusicssStore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Genre = c.String(),
                        Artist = c.String(),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlbumUrl = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Albums");
        }
    }
}
