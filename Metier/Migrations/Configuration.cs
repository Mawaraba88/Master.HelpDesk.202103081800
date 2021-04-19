namespace Metier.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Outils;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Metier.ModeleHelpDesk>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Metier.ModeleHelpDesk context)
        {

            //this.SeedRoles(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

       /* private void SeedRoles(Metier.ModeleHelpDesk context)
        {
            context.Roles.AddOrUpdate(x => x.Libelle, new IdentityRole(GlobalConstants.AdminRole));
            context.SaveChanges();
        }*/
    }
}
