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

            context.Cities.AddOrUpdate(y => y.CityId,
                new City() { CityId = 1, Name = "Greendale" },
                new City() { CityId = 2, Name = "Franklin" },
                new City() { CityId = 3, Name = "GreenField" },
                new City() { CityId = 4, Name = "Minneapolis"});

            context.ZipCodes.AddOrUpdate(y => y.ZipCodeId,
                new ZipCode() { ZipCodeId = 1, Zip = 53129 },
                new ZipCode() { ZipCodeId = 2, Zip = 53132 },
                new ZipCode() { ZipCodeId = 3, Zip = 53228 },
                new ZipCode() { ZipCodeId = 4, Zip = 53220 },
                new ZipCode() { ZipCodeId = 5, Zip = 53221},
                new ZipCode() { ZipCodeId = 6, Zip = 55406 },
                new ZipCode() { ZipCodeId = 7, Zip = 55417 });

            context.States.AddOrUpdate(y => y.StateId,
                new State() { StateId = 1, Name = "WI" },
                new State() { StateId = 2, Name = "MI" });

        }
    }
}
