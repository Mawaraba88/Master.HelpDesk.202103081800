namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Personnes", "RoleID", c => c.Int());
            AddColumn("dbo.Personnes", "ProfilID", c => c.Int());
            CreateIndex("dbo.Personnes", "RoleID");
            CreateIndex("dbo.Personnes", "ProfilID");
            AddForeignKey("dbo.Personnes", "RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.Personnes", "ProfilID", "dbo.Profils", "ProfilID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnes", "ProfilID", "dbo.Profils");
            DropForeignKey("dbo.Personnes", "RoleID", "dbo.Roles");
            DropIndex("dbo.Personnes", new[] { "ProfilID" });
            DropIndex("dbo.Personnes", new[] { "RoleID" });
            DropColumn("dbo.Personnes", "ProfilID");
            DropColumn("dbo.Personnes", "RoleID");
            DropTable("dbo.Profils");
            DropTable("dbo.Roles");
        }
    }
}
