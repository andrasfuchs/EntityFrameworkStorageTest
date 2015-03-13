namespace StorageTest.DataModel.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StorageTest.DataModel.DvdContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StorageTest.DataModel.DvdContext context)
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

            // insert some file genres
            context.Genres.AddOrUpdate(
                g => g.Name,
                new Genre() { Name = "Action" },
                new Genre() { Name = "SciFi" },
                new Genre() { Name = "Comedy" },
                new Genre() { Name = "Romance" }
                );

            // some roles
            context.Roles.AddOrUpdate(
                r => r.Name,
                new Role() { Name = "Lead" },
                new Role() { Name = "Supporting" },
                new Role() { Name = "Background" }
                );

            // add some actors
            context.Actors.AddOrUpdate(
                p => new { p.Surname, p.Name },
                new Actor()
                {
                    Name = "Chris",
                    Surname = "Pine",
                    Note = "Born in Los Angeles, California"
                },
                new Actor()
                {
                    Name = "Zachary",
                    Surname = "Quinto",
                    Note = "Zachary Quinto graduated from Central Catholic High School in Pittsburgh"
                },
                new Actor()
                {
                    Name = "Tom",
                    Surname = "Cruise"
                });

            // add a producer
            context.Producers.AddOrUpdate(
                p => p.FullName,
                new Producer()
                {
                    FullName = "J.J. Abrams",
                    Email = "jj.adams@producer.com",
                    Note = "Born: Jeffrey Jacob Abrams"
                });
        }
    }
}
