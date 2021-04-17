namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "CommentaireID", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "CommentairesID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "CommentairesID", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "CommentaireID");
        }
    }
}
