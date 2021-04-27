namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Commentaires", new[] { "Assistant_ID" });
            DropColumn("dbo.Commentaires", "AssistantID");
            RenameColumn(table: "dbo.Commentaires", name: "Assistant_ID", newName: "AssistantID");
            AlterColumn("dbo.Commentaires", "AssistantID", c => c.Int());
            CreateIndex("dbo.Commentaires", "AssistantID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Commentaires", new[] { "AssistantID" });
            AlterColumn("dbo.Commentaires", "AssistantID", c => c.String());
            RenameColumn(table: "dbo.Commentaires", name: "AssistantID", newName: "Assistant_ID");
            AddColumn("dbo.Commentaires", "AssistantID", c => c.String());
            CreateIndex("dbo.Commentaires", "Assistant_ID");
        }
    }
}
