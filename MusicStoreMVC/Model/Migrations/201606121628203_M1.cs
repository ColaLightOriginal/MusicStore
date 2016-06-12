namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Albums", "Artist", c => c.String(nullable: false));
            AlterColumn("dbo.Albums", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "Title", c => c.String());
            AlterColumn("dbo.Albums", "Artist", c => c.String());
            AlterColumn("dbo.Albums", "Genre", c => c.String());
        }
    }
}
