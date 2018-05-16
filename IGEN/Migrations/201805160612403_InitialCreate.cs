namespace IGEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BigPic = c.String(nullable: false),
                        Header = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Author = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Game_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Games", t => t.Game_ID, cascadeDelete: true)
                .Index(t => t.Game_ID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CoverArt = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Developer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Gamedevelopers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Game_ID", "dbo.Games");
            DropIndex("dbo.Articles", new[] { "Game_ID" });
            DropTable("dbo.Gamedevelopers");
            DropTable("dbo.Games");
            DropTable("dbo.Articles");
        }
    }
}
