namespace DCC_TrashCollector.Migrations
{
    using DCC_TrashCollector.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DCC_TrashCollector.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DCC_TrashCollector.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Days.AddOrUpdate(x => x.DayId,
                new Day() { DayId = 1, DayChoosen = "Monday"},
                new Day() { DayId = 2, DayChoosen = "Tuesday" },
                new Day() { DayId = 3, DayChoosen = "Wednesday"},
                new Day() { DayId = 4, DayChoosen = "Thursday" },
                new Day() { DayId = 5, DayChoosen = "Friday" });


        }
    }
}
