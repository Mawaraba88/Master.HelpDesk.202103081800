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
                    })
                .PrimaryKey(t => t.CommentaireID);
            
            CreateTable(
                "dbo.Historiques",
                c => new
                    {
                        HistoriqueID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.HistoriqueID);
            
            CreateTable(
                "dbo.Motifs",
                c => new
                    {
                        MotifID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.MotifID);
            
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
                    })
                .PrimaryKey(t => t.PieceJointeID);
            
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
            DropForeignKey("dbo.Assistants", "RoleID", "dbo.Roles");
            DropIndex("dbo.Assistants", new[] { "RoleID" });
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Types");
            DropTable("dbo.Statuts");
            DropTable("dbo.Priorites");
            DropTable("dbo.PieceJointes");
            DropTable("dbo.Niveaux");
            DropTable("dbo.Motifs");
            DropTable("dbo.Historiques");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Categories");
            DropTable("dbo.Roles");
            DropTable("dbo.Assistants");
            DropTable("dbo.Applications");
        }
    }
}
