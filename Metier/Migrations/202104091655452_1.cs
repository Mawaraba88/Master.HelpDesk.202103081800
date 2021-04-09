namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationID);
            
            CreateTable(
                "dbo.Assistants",
                c => new
                    {
                        AssistantID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssistantID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.CategorieID);
            
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        CommentaireID = c.Int(nullable: false, identity: true),
                        Contenu = c.String(),
                        Ticket_TicketID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentaireID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID)
                .Index(t => t.Ticket_TicketID);
            
            CreateTable(
                "dbo.Criticites",
                c => new
                    {
                        CriticiteID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.CriticiteID);
            
            CreateTable(
                "dbo.Environnements",
                c => new
                    {
                        EnvironnementID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.EnvironnementID);
            
            CreateTable(
                "dbo.Historiques",
                c => new
                    {
                        HistoriqueID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Ticket_TicketID = c.Int(),
                    })
                .PrimaryKey(t => t.HistoriqueID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID)
                .Index(t => t.Ticket_TicketID);
            
            CreateTable(
                "dbo.Niveaux",
                c => new
                    {
                        NiveauID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.NiveauID);
            
            CreateTable(
                "dbo.PieceJointes",
                c => new
                    {
                        PieceJointeID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Ticket_TicketID = c.Int(),
                    })
                .PrimaryKey(t => t.PieceJointeID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID)
                .Index(t => t.Ticket_TicketID);
            
            CreateTable(
                "dbo.Priorites",
                c => new
                    {
                        PrioriteID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.PrioriteID);
            
            CreateTable(
                "dbo.Statuts",
                c => new
                    {
                        StatutID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.StatutID);
            
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
                        Temps = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.Assistants", t => t.AssistantID)
                .ForeignKey("dbo.Categories", t => t.CategorieID, cascadeDelete: true)
                .ForeignKey("dbo.Criticites", t => t.CriticiteID, cascadeDelete: true)
                .ForeignKey("dbo.Environnements", t => t.EnvironnementID, cascadeDelete: true)
                .ForeignKey("dbo.Niveaux", t => t.NiveauID, cascadeDelete: true)
                .ForeignKey("dbo.Priorites", t => t.PrioriteID, cascadeDelete: true)
                .ForeignKey("dbo.Resolutions", t => t.ResolutionID, cascadeDelete: true)
                .ForeignKey("dbo.Statuts", t => t.StatutID, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurID, cascadeDelete: true)
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
            
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        ResolutionID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.ResolutionID);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        UtilisateurID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UtilisateurID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UtilisateurID", "dbo.Utilisateurs");
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
            DropForeignKey("dbo.Tickets", "AssistantID", "dbo.Assistants");
            DropForeignKey("dbo.Tickets", "ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.Assistants", "RoleID", "dbo.Roles");
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
            DropIndex("dbo.PieceJointes", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Historiques", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Commentaires", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Assistants", new[] { "RoleID" });
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Types");
            DropTable("dbo.Resolutions");
            DropTable("dbo.Tickets");
            DropTable("dbo.Statuts");
            DropTable("dbo.Priorites");
            DropTable("dbo.PieceJointes");
            DropTable("dbo.Niveaux");
            DropTable("dbo.Historiques");
            DropTable("dbo.Environnements");
            DropTable("dbo.Criticites");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Categories");
            DropTable("dbo.Roles");
            DropTable("dbo.Assistants");
            DropTable("dbo.Applications");
        }
    }
}
