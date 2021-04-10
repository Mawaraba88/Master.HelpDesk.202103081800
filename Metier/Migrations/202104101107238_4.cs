namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Applications");
        }
    }
}
