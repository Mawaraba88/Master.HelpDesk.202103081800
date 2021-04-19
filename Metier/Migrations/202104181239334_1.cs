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
                        Service = c.String(),
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
                "dbo.Commentaires",
                c => new
                    {
                        CommentaireID = c.Int(nullable: false, identity: true),
                        Contenu = c.String(nullable: false, maxLength: 1000),
                        AssistantID = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        Personne_ID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentaireID)
                .ForeignKey("dbo.Personnes", t => t.AssistantID, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.Personne_ID)
                .Index(t => t.AssistantID)
                .Index(t => t.TicketId)
                .Index(t => t.Personne_ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        Resume = c.String(),
                        DateEcheance = c.DateTime(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        AssistantID = c.Int(),
                        CategorieID = c.Int(nullable: false),
                        PieceJointeID = c.Int(),
                        Personne_ID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Personnes", t => t.AssistantID)
                .ForeignKey("dbo.Categories", t => t.CategorieID, cascadeDelete: true)
                .ForeignKey("dbo.PieceJointes", t => t.PieceJointeID)
                .ForeignKey("dbo.Personnes", t => t.Personne_ID)
                .Index(t => t.AssistantID)
                .Index(t => t.CategorieID)
                .Index(t => t.PieceJointeID)
                .Index(t => t.Personne_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.CategorieID);
            
            CreateTable(
                "dbo.Historiques",
                c => new
                    {
                        HistoriqueID = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        Libelle = c.String(),
                        AssistantID = c.Int(),
                        Priorite = c.Int(nullable: false),
                        PrioriteID = c.Int(nullable: false),
                        Resolution = c.Int(nullable: false),
                        ResolutionID = c.Int(nullable: false),
                        Statut = c.Int(nullable: false),
                        StatutID = c.Int(nullable: false),
                        TicketID = c.Int(nullable: false),
                        PieceJointeID = c.Int(),
                    })
                .PrimaryKey(t => t.HistoriqueID)
                .ForeignKey("dbo.Personnes", t => t.AssistantID)
                .ForeignKey("dbo.PieceJointes", t => t.PieceJointeID)
                .ForeignKey("dbo.Tickets", t => t.TicketID, cascadeDelete: true)
                .Index(t => t.AssistantID)
                .Index(t => t.TicketID)
                .Index(t => t.PieceJointeID);
            
            CreateTable(
                "dbo.PieceJointes",
                c => new
                    {
                        PieceJointeID = c.Int(nullable: false, identity: true),
                        Content = c.Binary(),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.PieceJointeID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Profils",
                c => new
                    {
                        ProfilID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Actif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProfilID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnes", "ProfilID", "dbo.Profils");
            DropForeignKey("dbo.Tickets", "Personne_ID", "dbo.Personnes");
            DropForeignKey("dbo.Commentaires", "Personne_ID", "dbo.Personnes");
            DropForeignKey("dbo.Personnes", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Tickets", "PieceJointeID", "dbo.PieceJointes");
            DropForeignKey("dbo.Historiques", "TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Historiques", "PieceJointeID", "dbo.PieceJointes");
            DropForeignKey("dbo.Historiques", "AssistantID", "dbo.Personnes");
            DropForeignKey("dbo.Commentaires", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "CategorieID", "dbo.Categories");
            DropForeignKey("dbo.Tickets", "AssistantID", "dbo.Personnes");
            DropForeignKey("dbo.Commentaires", "AssistantID", "dbo.Personnes");
            DropIndex("dbo.Historiques", new[] { "PieceJointeID" });
            DropIndex("dbo.Historiques", new[] { "TicketID" });
            DropIndex("dbo.Historiques", new[] { "AssistantID" });
            DropIndex("dbo.Tickets", new[] { "Personne_ID" });
            DropIndex("dbo.Tickets", new[] { "PieceJointeID" });
            DropIndex("dbo.Tickets", new[] { "CategorieID" });
            DropIndex("dbo.Tickets", new[] { "AssistantID" });
            DropIndex("dbo.Commentaires", new[] { "Personne_ID" });
            DropIndex("dbo.Commentaires", new[] { "TicketId" });
            DropIndex("dbo.Commentaires", new[] { "AssistantID" });
            DropIndex("dbo.Personnes", new[] { "ProfilID" });
            DropIndex("dbo.Personnes", new[] { "RoleID" });
            DropTable("dbo.Profils");
            DropTable("dbo.Roles");
            DropTable("dbo.PieceJointes");
            DropTable("dbo.Historiques");
            DropTable("dbo.Categories");
            DropTable("dbo.Tickets");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Personnes");
            DropTable("dbo.Applications");
        }
    }
}
