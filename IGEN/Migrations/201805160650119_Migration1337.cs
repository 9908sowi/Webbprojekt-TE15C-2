namespace IGEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1337 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Articles", name: "Game_ID", newName: "GameID");
            RenameIndex(table: "dbo.Articles", name: "IX_Game_ID", newName: "IX_GameID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Articles", name: "IX_GameID", newName: "IX_Game_ID");
            RenameColumn(table: "dbo.Articles", name: "GameID", newName: "Game_ID");
        }
    }
}
