using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace StorageTest.DataModel
{
    public class DvdContext : DbContext
    {
        static DvdContext()
        {
            // Not initialize database
            //  Database.SetInitializer<ProjectDatabase>(null);
            // Database initialize
            Database.SetInitializer<DvdContext>(new DbInitializer());
            using (DvdContext db = new DvdContext())
                db.Database.Initialize(false);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<FilmActorRole> FilmActorRoles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Note> Notes { get; set; }
    }

    class DbInitializer : DropCreateDatabaseIfModelChanges<DvdContext>
    {
        protected override void Seed(DvdContext context)
        {
            // insert some file generes
            Genre action = new Genre() { Name = "Action" };
            context.Genres.Add(action);
            context.Genres.Add(new Genre() { Name = "SciFi" });
            context.Genres.Add(new Genre() { Name = "Comedy" });
            context.Genres.Add(new Genre() { Name = "Romance" });
            
            // some roles
            context.Roles.Add(new Role(){Name = "Lead"});
            context.Roles.Add(new Role(){Name = "Supporting"});
            context.Roles.Add(new Role(){Name = "Background"});
            
            // some actors
            context.Actors.Add(new Actor()
            {
                Name ="Chris",
                Surname ="Pine",
                Note = "Born in Los Angeles, California"
            });
            context.Actors.Add(new Actor()
            {
                Name = "Zachary",
                Surname = "Quinto",
                Note = "Zachary Quinto graduated from Central Catholic High School in Pittsburgh"
            });
            context.Actors.Add(new Actor()
            {
                Name = "Tom",
                Surname = "Cruise"
            });

            // producers
            Producer jjAbrams = new Producer()
            {
                FullName = "J.J. Abrams",
                Email = "jj.adams@producer.com",
                Note = "Born: Jeffrey Jacob Abrams"
            };
            context.Producers.Add(jjAbrams);

            // films
            Film missionImpossible = new Film()
            {
                Title = "Mission: Impossible III",
                ReleaseYear = 2006,
                Duration = 126,
                Story = "Ethan Hunt comes face to face with a dangerous and ...",
                Genre = action
            };
            missionImpossible.Producers = new List<Producer>();
            missionImpossible.Producers.Add(jjAbrams);
            context.Films.Add(missionImpossible);

            base.Seed(context);
        }
    }
}
