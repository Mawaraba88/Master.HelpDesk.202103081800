namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        TypeID = c.Int(nullable: false),
                        Resume = c.String(),
                        DateEcheance = c.DateTime(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateResolution = c.DateTime(nullable: false),
                        Description = c.String(),
                        UtilisateurID = c.Int(nullable: false),
                        ApplicationID = c.Int(nullable: false),
                        AssistantID = c.Int(),
                        PieceJointeID = c.Int(nullable: false),
                        HistoriqueID = c.Int(nullable: false),
                        CategorieID = c.Int(nullable: false),
                        NiveauID = c.Int(nullable: false),
                        PrioriteID = c.Int(nullable: false),
                        ResolutionID = c.Int(nullable: false),
                        StatutID = c.Int(nullable: false),
                        EnvironnementID = c.Int(nullable: false),
                        CriticiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Applications", t => t.ApplicationID, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.AssistantID)
                .ForeignKey("dbo.Categories", t => t.CategorieID, cascadeDelete: true)
                .ForeignKey("dbo.Criticites", t => t.CriticiteID, cascadeDelete: true)
                .ForeignKey("dbo.Environnements", t => t.EnvironnementID, cascadeDelete: true)
                .ForeignKey("dbo.Niveaux", t => t.NiveauID, cascadeDelete: true)
                .ForeignKey("dbo.Priorites", t => t.PrioriteID, cascadeDelete: true)
                .ForeignKey("dbo.Resolutions", t => t.ResolutionID, cascadeDelete: true)
                .ForeignKey("dbo.Statuts", t => t.StatutID, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.UtilisateurID, cascadeDelete: true)
                .Index(t => t.TypeID)
                .Index(t => t.UtilisateurID)
                .Index(t => t.ApplicationID)
                .Index(t => t.AssistantID)
                .Index(t => t.CategorieID)
                .Index(t => t.NiveauID)
                .Index(t => t.PrioriteID)
                .Index(t => t.ResolutionID)
                .Index(t => t.StatutID)
                .Index(t => t.EnvironnementID)
                .Index(t => t.CriticiteID);
            
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
            DropForeignKey("dbo.Tickets", "UtilisateurID", "dbo.Personnes");
            DropForeignKey("dbo.Tickets", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Tickets", "StatutID", "dbo.Statuts");
            DropForeignKey("dbo.Tickets", "ResolutionID", "dbo.Resolutions");
            DropForeignKey("dbo.Tickets", "PrioriteID", "dbo.Priorites");
            DropForeignKey("dbo.PieceJointes", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "NiveauID", "dbo.Niveaux");
            DropForeignKey("dbo.Historiques", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "EnvironnementID", "dbo.Environnements");
            DropForeignKey("dbo.Tickets", "CriticiteID", "dbo.Criticites");
            DropForeignKey("dbo.Commentaires", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "CategorieID", "dbo.Categories");
            DropForeignKey("dbo.Tickets", "AssistantID", "dbo.Personnes");
            DropForeignKey("dbo.Tickets", "ApplicationID", "dbo.Applications");
            DropIndex("dbo.PieceJointes", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Historiques", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Commentaires", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Tickets", new[] { "CriticiteID" });
            DropIndex("dbo.Tickets", new[] { "EnvironnementID" });
            DropIndex("dbo.Tickets", new[] { "StatutID" });
            DropIndex("dbo.Tickets", new[] { "ResolutionID" });
            DropIndex("dbo.Tickets", new[] { "PrioriteID" });
            DropIndex("dbo.Tickets", new[] { "NiveauID" });
            DropIndex("dbo.Tickets", new[] { "CategorieID" });
            DropIndex("dbo.Tickets", new[] { "AssistantID" });
            DropIndex("dbo.Tickets", new[] { "ApplicationID" });
            DropIndex("dbo.Tickets", new[] { "UtilisateurID" });
            DropIndex("dbo.Tickets", new[] { "TypeID" });
            DropColumn("dbo.PieceJointes", "Ticket_TicketID");
            DropColumn("dbo.Historiques", "Ticket_TicketID");
            DropColumn("dbo.Commentaires", "Ticket_TicketID");
            DropTable("dbo.Tickets");
        }
    }
}
