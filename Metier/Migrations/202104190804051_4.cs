namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tickets", name: "Assistant_ID", newName: "AssistantID");
            RenameIndex(table: "dbo.Tickets", name: "IX_Assistant_ID", newName: "IX_AssistantID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tickets", name: "IX_AssistantID", newName: "IX_Assistant_ID");
            RenameColumn(table: "dbo.Tickets", name: "AssistantID", newName: "Assistant_ID");
        }
    }
}
