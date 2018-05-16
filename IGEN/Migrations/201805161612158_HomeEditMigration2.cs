namespace IGEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeEditMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.HomeEdits", name: "ArticleID", newName: "Article_ID");
            RenameIndex(table: "dbo.HomeEdits", name: "IX_ArticleID", newName: "IX_Article_ID");
            AddColumn("dbo.HomeEdits", "FrontPicID", c => c.Int());
            AddColumn("dbo.HomeEdits", "CardPic1ID", c => c.Int());
            AddColumn("dbo.HomeEdits", "CardPic2ID", c => c.Int());
            AddColumn("dbo.HomeEdits", "CardPic3ID", c => c.Int());
            AddColumn("dbo.HomeEdits", "CardPic4ID", c => c.Int());
            AddColumn("dbo.HomeEdits", "CardPic5ID", c => c.Int());
            AddColumn("dbo.HomeEdits", "CardPic6ID", c => c.Int());
            CreateIndex("dbo.HomeEdits", "FrontPicID");
            CreateIndex("dbo.HomeEdits", "CardPic1ID");
            CreateIndex("dbo.HomeEdits", "CardPic2ID");
            CreateIndex("dbo.HomeEdits", "CardPic3ID");
            CreateIndex("dbo.HomeEdits", "CardPic4ID");
            CreateIndex("dbo.HomeEdits", "CardPic5ID");
            CreateIndex("dbo.HomeEdits", "CardPic6ID");
            AddForeignKey("dbo.HomeEdits", "CardPic1ID", "dbo.Articles", "ID");
            AddForeignKey("dbo.HomeEdits", "CardPic2ID", "dbo.Articles", "ID");
            AddForeignKey("dbo.HomeEdits", "CardPic3ID", "dbo.Articles", "ID");
            AddForeignKey("dbo.HomeEdits", "CardPic4ID", "dbo.Articles", "ID");
            AddForeignKey("dbo.HomeEdits", "CardPic5ID", "dbo.Articles", "ID");
            AddForeignKey("dbo.HomeEdits", "CardPic6ID", "dbo.Articles", "ID");
            AddForeignKey("dbo.HomeEdits", "FrontPicID", "dbo.Articles", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HomeEdits", "FrontPicID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic6ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic5ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic4ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic3ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic2ID", "dbo.Articles");
            DropForeignKey("dbo.HomeEdits", "CardPic1ID", "dbo.Articles");
            DropIndex("dbo.HomeEdits", new[] { "CardPic6ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic5ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic4ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic3ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic2ID" });
            DropIndex("dbo.HomeEdits", new[] { "CardPic1ID" });
            DropIndex("dbo.HomeEdits", new[] { "FrontPicID" });
            DropColumn("dbo.HomeEdits", "CardPic6ID");
            DropColumn("dbo.HomeEdits", "CardPic5ID");
            DropColumn("dbo.HomeEdits", "CardPic4ID");
            DropColumn("dbo.HomeEdits", "CardPic3ID");
            DropColumn("dbo.HomeEdits", "CardPic2ID");
            DropColumn("dbo.HomeEdits", "CardPic1ID");
            DropColumn("dbo.HomeEdits", "FrontPicID");
            RenameIndex(table: "dbo.HomeEdits", name: "IX_Article_ID", newName: "IX_ArticleID");
            RenameColumn(table: "dbo.HomeEdits", name: "Article_ID", newName: "ArticleID");
        }
    }
}
