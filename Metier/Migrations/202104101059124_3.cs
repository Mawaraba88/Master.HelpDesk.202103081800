namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.HistoriqueID);
            
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
                        Content = c.Binary(),
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
            DropTable("dbo.Types");
            DropTable("dbo.Statuts");
            DropTable("dbo.Resolutions");
            DropTable("dbo.Priorites");
            DropTable("dbo.PieceJointes");
            DropTable("dbo.Niveaux");
            DropTable("dbo.Historiques");
            DropTable("dbo.Environnements");
            DropTable("dbo.Criticites");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Categories");
        }
    }
}
