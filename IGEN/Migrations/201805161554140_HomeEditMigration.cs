namespace IGEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeEditMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeEdits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArticleID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Articles", t => t.ArticleID)
                .Index(t => t.ArticleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HomeEdits", "ArticleID", "dbo.Articles");
            DropIndex("dbo.HomeEdits", new[] { "ArticleID" });
            DropTable("dbo.HomeEdits");
        }
    }
}
