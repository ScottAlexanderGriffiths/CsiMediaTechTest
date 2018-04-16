namespace Data.Migrations
{
    using Records;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ValuesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.ValuesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var sortTypeRecord = new SortTypeRecord { Name = "Unordered" };
            context.Set<SortTypeRecord>().AddOrUpdate(sortTypeRecord);
            context.Set<SortTypeRecord>().AddOrUpdate(new SortTypeRecord { Name = "Ascending" });
            context.Set<SortTypeRecord>().AddOrUpdate(new SortTypeRecord { Name = "Descending" });

            context.Set<CurrentSortDirectionRecord>().AddOrUpdate(new CurrentSortDirectionRecord { SortType = sortTypeRecord });
        }
    }
}
