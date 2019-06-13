namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.DAL.KursyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication1.DAL.KursyContext";
        }

        protected override void Seed(WebApplication1.DAL.KursyContext context)
        {

            KursyInitializer.SeedKursyData(context);
            KursyInitializer.SeedUzytkownicy(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
