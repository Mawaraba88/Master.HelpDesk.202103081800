namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commentaires", "AssistantID", "dbo.Personnes");
            DropIndex("dbo.Commentaires", new[] { "AssistantID" });
            AddColumn("dbo.Commentaires", "Assistant_ID", c => c.Int());
            AlterColumn("dbo.Commentaires", "AssistantID", c => c.String());
            CreateIndex("dbo.Commentaires", "Assistant_ID");
            AddForeignKey("dbo.Commentaires", "Assistant_ID", "dbo.Personnes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commentaires", "Assistant_ID", "dbo.Personnes");
            DropIndex("dbo.Commentaires", new[] { "Assistant_ID" });
            AlterColumn("dbo.Commentaires", "AssistantID", c => c.Int(nullable: false));
            DropColumn("dbo.Commentaires", "Assistant_ID");
            CreateIndex("dbo.Commentaires", "AssistantID");
            AddForeignKey("dbo.Commentaires", "AssistantID", "dbo.Personnes", "ID", cascadeDelete: true);
        }
    }
}
