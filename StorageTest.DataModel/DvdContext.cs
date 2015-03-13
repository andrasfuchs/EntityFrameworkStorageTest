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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DvdContext, StorageTest.DataModel.Migrations.Configuration>()); 
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<FilmActorRole> FilmActorRoles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
