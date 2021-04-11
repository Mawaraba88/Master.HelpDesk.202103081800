namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "NiveauID", "dbo.Niveaux");
            DropIndex("dbo.Tickets", new[] { "NiveauID" });
            DropColumn("dbo.Tickets", "NiveauID");
            DropTable("dbo.Niveaux");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Niveaux",
                c => new
                    {
                        NiveauID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.NiveauID);
            
            AddColumn("dbo.Tickets", "NiveauID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "NiveauID");
            AddForeignKey("dbo.Tickets", "NiveauID", "dbo.Niveaux", "NiveauID", cascadeDelete: true);
        }
    }
}
