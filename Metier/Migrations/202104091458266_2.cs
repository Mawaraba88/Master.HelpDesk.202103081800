namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        Temps = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UtilisateurID = c.Int(nullable: false),
                        ApplicationID = c.Int(nullable: false),
                        AssistantID = c.Int(),
                        PieceJointeID = c.Int(nullable: false),
                        HistoriqueID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        CategorieID = c.Int(nullable: false),
                        NiveauID = c.Int(nullable: false),
                        PrioriteID = c.Int(nullable: false),
                        StatutID = c.Int(nullable: false),
                        MotifID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Applications", t => t.ApplicationID, cascadeDelete: true)
                .ForeignKey("dbo.Assistants", t => t.AssistantID)
                .ForeignKey("dbo.Categories", t => t.CategorieID, cascadeDelete: true)
                .ForeignKey("dbo.Motifs", t => t.MotifID, cascadeDelete: true)
                .ForeignKey("dbo.Niveaux", t => t.NiveauID, cascadeDelete: true)
                .ForeignKey("dbo.Priorites", t => t.PrioriteID, cascadeDelete: true)
                .ForeignKey("dbo.Statuts", t => t.StatutID, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurID, cascadeDelete: true)
                .Index(t => t.UtilisateurID)
                .Index(t => t.ApplicationID)
                .Index(t => t.AssistantID)
                .Index(t => t.TypeID)
                .Index(t => t.CategorieID)
                .Index(t => t.NiveauID)
                .Index(t => t.PrioriteID)
                .Index(t => t.StatutID)
                .Index(t => t.MotifID);
            
            AddColumn("dbo.Commentaires", "Ticket_TicketID", c => c.Int());
            AddColumn("dbo.Historiques", "Ticket_TicketID", c => c.Int());
            AddColumn("dbo.PieceJointes", "Ticket_TicketID", c => c.Int());
            CreateIndex("dbo.Commentaires", "Ticket_TicketID");
            CreateIndex("dbo.Historiques", "Ticket_TicketID");
            CreateIndex("dbo.PieceJointes", "Ticket_TicketID");
            AddForeignKey("dbo.Commentaires", "Ticket_TicketID", "dbo.Tickets", "TicketID");
            AddForeignKey("dbo.Historiques", "Ticket_TicketID", "dbo.Tickets", "TicketID");
            AddForeignKey("dbo.PieceJointes", "Ticket_TicketID", "dbo.Tickets", "TicketID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UtilisateurID", "dbo.Utilisateurs");
            DropForeignKey("dbo.Tickets", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Tickets", "StatutID", "dbo.Statuts");
            DropForeignKey("dbo.Tickets", "PrioriteID", "dbo.Priorites");
            DropForeignKey("dbo.PieceJointes", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "NiveauID", "dbo.Niveaux");
            DropForeignKey("dbo.Tickets", "MotifID", "dbo.Motifs");
            DropForeignKey("dbo.Historiques", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Commentaires", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "CategorieID", "dbo.Categories");
            DropForeignKey("dbo.Tickets", "AssistantID", "dbo.Assistants");
            DropForeignKey("dbo.Tickets", "ApplicationID", "dbo.Applications");
            DropIndex("dbo.Tickets", new[] { "MotifID" });
            DropIndex("dbo.Tickets", new[] { "StatutID" });
            DropIndex("dbo.Tickets", new[] { "PrioriteID" });
            DropIndex("dbo.Tickets", new[] { "NiveauID" });
            DropIndex("dbo.Tickets", new[] { "CategorieID" });
            DropIndex("dbo.Tickets", new[] { "TypeID" });
            DropIndex("dbo.Tickets", new[] { "AssistantID" });
            DropIndex("dbo.Tickets", new[] { "ApplicationID" });
            DropIndex("dbo.Tickets", new[] { "UtilisateurID" });
            DropIndex("dbo.PieceJointes", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Historiques", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Commentaires", new[] { "Ticket_TicketID" });
            DropColumn("dbo.PieceJointes", "Ticket_TicketID");
            DropColumn("dbo.Historiques", "Ticket_TicketID");
            DropColumn("dbo.Commentaires", "Ticket_TicketID");
            DropTable("dbo.Tickets");
        }
    }
}
