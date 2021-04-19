namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "CategorieID", "dbo.Categories");
            DropIndex("dbo.Tickets", new[] { "CategorieID" });
            RenameColumn(table: "dbo.Tickets", name: "AssistantID", newName: "Assistant_ID");
            RenameIndex(table: "dbo.Tickets", name: "IX_AssistantID", newName: "IX_Assistant_ID");
            AddColumn("dbo.Tickets", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "ApplicationID", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Priorite", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Resolution", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Statut", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Environnement", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Criticite", c => c.Int(nullable: false));
            AddColumn("dbo.Historiques", "Environnement", c => c.Int(nullable: false));
            AddColumn("dbo.Historiques", "Criticite", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "ApplicationID");
            AddForeignKey("dbo.Tickets", "ApplicationID", "dbo.Applications", "ApplicationID", cascadeDelete: true);
            DropColumn("dbo.Tickets", "CategorieID");
            DropColumn("dbo.Historiques", "PrioriteID");
            DropColumn("dbo.Historiques", "ResolutionID");
            DropColumn("dbo.Historiques", "StatutID");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.CategorieID);
            
            AddColumn("dbo.Historiques", "StatutID", c => c.Int(nullable: false));
            AddColumn("dbo.Historiques", "ResolutionID", c => c.Int(nullable: false));
            AddColumn("dbo.Historiques", "PrioriteID", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "CategorieID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "ApplicationID", "dbo.Applications");
            DropIndex("dbo.Tickets", new[] { "ApplicationID" });
            DropColumn("dbo.Historiques", "Criticite");
            DropColumn("dbo.Historiques", "Environnement");
            DropColumn("dbo.Tickets", "Criticite");
            DropColumn("dbo.Tickets", "Environnement");
            DropColumn("dbo.Tickets", "Statut");
            DropColumn("dbo.Tickets", "Resolution");
            DropColumn("dbo.Tickets", "Priorite");
            DropColumn("dbo.Tickets", "ApplicationID");
            DropColumn("dbo.Tickets", "Type");
            RenameIndex(table: "dbo.Tickets", name: "IX_Assistant_ID", newName: "IX_AssistantID");
            RenameColumn(table: "dbo.Tickets", name: "Assistant_ID", newName: "AssistantID");
            CreateIndex("dbo.Tickets", "CategorieID");
            AddForeignKey("dbo.Tickets", "CategorieID", "dbo.Categories", "CategorieID", cascadeDelete: true);
        }
    }
}
