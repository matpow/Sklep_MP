namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Repozytorium.Models;

    public sealed class Configuration : DbMigrationsConfiguration<Repozytorium.Models.SklepContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
            ContextKey = "Repozytorium.Models.SklepContext";
        }

        protected override void Seed(Repozytorium.Models.SklepContext context)
        {
            SklepIinitializer.SeedSklepData(context);
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Do debugowania metody seed
            // if (System.Diagnostics.Debugger.IsAttached == false)
            // System.Diagnostics.Debugger.Launch();
        }
    }
}
