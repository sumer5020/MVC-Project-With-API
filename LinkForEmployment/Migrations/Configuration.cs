namespace LinkForEmployment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LinkForEmployment.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LinkForEmployment.Models.ApplicationDbContext";
        }

        protected override void Seed(LinkForEmployment.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "abdulamjed alshiri" },
            //      new Person { FullName = "husseen alkobati" },
            //      new Person { FullName = "sumer alkadasi" },
            //      new Person { FullName = "mahmoud alansi" },
            //      new Person { FullName = "majd almiri" }
            //    );
            //
        }
    }
}
