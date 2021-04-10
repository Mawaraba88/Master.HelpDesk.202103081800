namespace Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Personne", newName: "Personnes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Personnes", newName: "Personne");
        }
    }
}
