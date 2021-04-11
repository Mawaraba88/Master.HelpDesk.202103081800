namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "DateEcheance");
            DropColumn("dbo.Tickets", "DateCreation");
            DropColumn("dbo.Tickets", "DateResolution");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "DateResolution", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "DateCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "DateEcheance", c => c.DateTime(nullable: false));
        }
    }
}
