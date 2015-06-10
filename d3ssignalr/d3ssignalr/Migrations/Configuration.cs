namespace d3ssignalr.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<d3ssignalr.Models.ReportLogServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(d3ssignalr.Models.ReportLogServiceContext context)
        {
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

            context.ReportLogs.AddOrUpdate(x => x.Id,
                new Models.ReportLog { Id = 1, Stamp = DateTime.Now, Status = "Running" },
                new Models.ReportLog { Id = 2, Stamp = DateTime.Now, Status = "Stopped" },
                new Models.ReportLog { Id = 3, Stamp = DateTime.Now, Status = "Paused" }
            );
        }
    }
}
