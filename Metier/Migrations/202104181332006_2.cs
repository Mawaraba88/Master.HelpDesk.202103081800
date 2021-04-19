namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "DateEcheance", c => c.DateTime());
            AlterColumn("dbo.Tickets", "DateCreation", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "DateEcheance", c => c.DateTime(nullable: false));
        }
    }
}
