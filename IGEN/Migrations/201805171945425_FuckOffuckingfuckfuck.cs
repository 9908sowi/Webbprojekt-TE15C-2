namespace IGEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FuckOffuckingfuckfuck : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false),
                        BigPic = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Author = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CoverArt = c.String(nullable: false),
                        Developer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HomeEdits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FrontPicID = c.Int(),
                        CardPic1ID = c.Int(),
                        CardPic2ID = c.Int(),
                        CardPic3ID = c.Int(),
                        CardPic4ID = c.Int(),
                        CardPic5ID = c.Int(),
                        CardPic6ID = c.Int(),
                        Article_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Articles", t => t.CardPic1ID)
                .ForeignKey("dbo.Articles", t => t.CardPic2ID)
                .ForeignKey("dbo.Articles", t => t.CardPic3ID)
                .ForeignKey("dbo.Articles", t => t.CardPic4ID)
                .ForeignKey("dbo.Articles", t => t.CardPic5ID)
                .ForeignKey("dbo.Articles", t => t.CardPic6ID)
                .ForeignKey("dbo.Articles", t => t.FrontPicID)
                .ForeignKey("dbo.Articles", t => t.Article_ID)
                .Index(t => t.FrontPicID)
                .Index(t => t.CardPic1ID)
                .Index(t => t.CardPic2ID)
                .Index(t => t.CardPic3ID)
                .Index(t => t.CardPic4ID)
                .Index(t => t.CardPic5ID)
                .Index(t => t.CardPic6ID)
                .Index(t => t.Article_ID);
            
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
            DropForeignKey("dbo.HomeEdits", "Article_ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "FrontPicID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic6ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic5ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic4ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic3ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic2ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic1ID", "dbo.Articles");
            DropForeignKey("dbo.Articles", "GameID", "dbo.Games");
            DropIndex("dbo.HomeEdits", new[] { "Article_ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic6ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic5ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic4ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic3ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic2ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic1ID" });
            DropIndex("dbo.HomeEdits", new[] { "FrontPicID" });
            DropIndex("dbo.Articles", new[] { "GameID" });
            DropTable("dbo.Gamedevelopers");
            DropTable("dbo.HomeEdits");
            DropTable("dbo.Games");
            DropTable("dbo.Articles");
        }
    }
}
