namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personnes", "Nom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Personnes", "Prenom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tickets", "DateEcheance", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "DateCreation", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "DateCreation", c => c.DateTime());
            AlterColumn("dbo.Tickets", "DateEcheance", c => c.DateTime());
            AlterColumn("dbo.Personnes", "Prenom", c => c.String());
            AlterColumn("dbo.Personnes", "Nom", c => c.String());
        }
    }
}
