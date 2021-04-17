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
                "dbo.Personnes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        MotDePasse = c.String(),
                        RoleID = c.Int(),
                        ProfilID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Profils", t => t.ProfilID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.ProfilID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
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
                .ForeignKey("dbo.Personnes", t => t.UtilisateurID, cascadeDelete: true)
                .ForeignKey("dbo.Priorites", t => t.PrioriteID, cascadeDelete: true)
                .ForeignKey("dbo.Resolutions", t => t.ResolutionID, cascadeDelete: true)
                .ForeignKey("dbo.Statuts", t => t.StatutID, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.ApplicationID)
                .Index(t => t.AssistantID)
                .Index(t => t.CategorieID)
                .Index(t => t.CriticiteID)
                .Index(t => t.EnvironnementID)
                .Index(t => t.UtilisateurID)
                .Index(t => t.PrioriteID)
                .Index(t => t.ResolutionID)
                .Index(t => t.StatutID)
                .Index(t => t.TypeID);
            
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
                        Contenu = c.String(nullable: false, maxLength: 1000),
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
                        DateCreation = c.DateTime(nullable: false),
                        Libelle = c.String(),
                        AssistantID = c.Int(),
                        PieceJointeID = c.Int(nullable: false),
                        PrioriteID = c.Int(nullable: false),
                        ResolutionID = c.Int(nullable: false),
                        StatutID = c.Int(nullable: false),
                        UtilisateurID = c.Int(nullable: false),
                        PieceJointe_PieceJointeID = c.Int(),
                        Ticket_TicketID = c.Int(),
                    })
                .PrimaryKey(t => t.HistoriqueID)
                .ForeignKey("dbo.Personnes", t => t.AssistantID)
                .ForeignKey("dbo.PieceJointes", t => t.PieceJointe_PieceJointeID)
                .ForeignKey("dbo.Priorites", t => t.PrioriteID, cascadeDelete: true)
                .ForeignKey("dbo.Resolutions", t => t.ResolutionID, cascadeDelete: true)
                .ForeignKey("dbo.Statuts", t => t.StatutID, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.UtilisateurID, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID)
                .Index(t => t.AssistantID)
                .Index(t => t.PieceJointe_PieceJointeID)
                .Index(t => t.PrioriteID)
                .Index(t => t.ResolutionID)
                .Index(t => t.StatutID)
                .Index(t => t.UtilisateurID)
                .Index(t => t.Ticket_TicketID);
            
            CreateTable(
                "dbo.PieceJointes",
                c => new
                    {
                        PieceJointeID = c.Int(nullable: false, identity: true),
                        Content = c.Binary(),
                        Libelle = c.String(),
                        Historique_HistoriqueID = c.Int(),
                        Ticket_TicketID = c.Int(),
                    })
                .PrimaryKey(t => t.PieceJointeID)
                .ForeignKey("dbo.Historiques", t => t.Historique_HistoriqueID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID)
                .Index(t => t.Historique_HistoriqueID)
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
                "dbo.Resolutions",
                c => new
                    {
                        ResolutionID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.ResolutionID);
            
            CreateTable(
                "dbo.Statuts",
                c => new
                    {
                        StatutID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.StatutID);
            
            CreateTable(
                "dbo.Profils",
                c => new
                    {
                        ProfilID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Actif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProfilID);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Tickets", "StatutID", "dbo.Statuts");
            DropForeignKey("dbo.Tickets", "ResolutionID", "dbo.Resolutions");
            DropForeignKey("dbo.Tickets", "PrioriteID", "dbo.Priorites");
            DropForeignKey("dbo.PieceJointes", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Historiques", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Historiques", "UtilisateurID", "dbo.Personnes");
            DropForeignKey("dbo.Tickets", "UtilisateurID", "dbo.Personnes");
            DropForeignKey("dbo.Personnes", "ProfilID", "dbo.Profils");
            DropForeignKey("dbo.Historiques", "StatutID", "dbo.Statuts");
            DropForeignKey("dbo.Historiques", "ResolutionID", "dbo.Resolutions");
            DropForeignKey("dbo.Historiques", "PrioriteID", "dbo.Priorites");
            DropForeignKey("dbo.PieceJointes", "Historique_HistoriqueID", "dbo.Historiques");
            DropForeignKey("dbo.Historiques", "PieceJointe_PieceJointeID", "dbo.PieceJointes");
            DropForeignKey("dbo.Historiques", "AssistantID", "dbo.Personnes");
            DropForeignKey("dbo.Tickets", "EnvironnementID", "dbo.Environnements");
            DropForeignKey("dbo.Tickets", "CriticiteID", "dbo.Criticites");
            DropForeignKey("dbo.Commentaires", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "CategorieID", "dbo.Categories");
            DropForeignKey("dbo.Tickets", "AssistantID", "dbo.Personnes");
            DropForeignKey("dbo.Tickets", "ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.Personnes", "RoleID", "dbo.Roles");
            DropIndex("dbo.Tickets", new[] { "TypeID" });
            DropIndex("dbo.Tickets", new[] { "StatutID" });
            DropIndex("dbo.Tickets", new[] { "ResolutionID" });
            DropIndex("dbo.Tickets", new[] { "PrioriteID" });
            DropIndex("dbo.PieceJointes", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Historiques", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Historiques", new[] { "UtilisateurID" });
            DropIndex("dbo.Tickets", new[] { "UtilisateurID" });
            DropIndex("dbo.Personnes", new[] { "ProfilID" });
            DropIndex("dbo.Historiques", new[] { "StatutID" });
            DropIndex("dbo.Historiques", new[] { "ResolutionID" });
            DropIndex("dbo.Historiques", new[] { "PrioriteID" });
            DropIndex("dbo.PieceJointes", new[] { "Historique_HistoriqueID" });
            DropIndex("dbo.Historiques", new[] { "PieceJointe_PieceJointeID" });
            DropIndex("dbo.Historiques", new[] { "AssistantID" });
            DropIndex("dbo.Tickets", new[] { "EnvironnementID" });
            DropIndex("dbo.Tickets", new[] { "CriticiteID" });
            DropIndex("dbo.Commentaires", new[] { "Ticket_TicketID" });
            DropIndex("dbo.Tickets", new[] { "CategorieID" });
            DropIndex("dbo.Tickets", new[] { "AssistantID" });
            DropIndex("dbo.Tickets", new[] { "ApplicationID" });
            DropIndex("dbo.Personnes", new[] { "RoleID" });
            DropTable("dbo.Types");
            DropTable("dbo.Profils");
            DropTable("dbo.Statuts");
            DropTable("dbo.Resolutions");
            DropTable("dbo.Priorites");
            DropTable("dbo.PieceJointes");
            DropTable("dbo.Historiques");
            DropTable("dbo.Environnements");
            DropTable("dbo.Criticites");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Categories");
            DropTable("dbo.Tickets");
            DropTable("dbo.Roles");
            DropTable("dbo.Personnes");
            DropTable("dbo.Applications");
        }
    }
}
