namespace StorageTest.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Note = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmActorRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilmTitleId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Character = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.FilmTitleId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.FilmTitleId)
                .Index(t => t.ActorId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Story = c.String(nullable: false, maxLength: 1000),
                        ReleaseYear = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Note = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProducerFilms",
                c => new
                    {
                        Producer_Id = c.Int(nullable: false),
                        Film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Producer_Id, t.Film_Id })
                .ForeignKey("dbo.Producers", t => t.Producer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Producer_Id)
                .Index(t => t.Film_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmActorRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.ProducerFilms", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.ProducerFilms", "Producer_Id", "dbo.Producers");
            DropForeignKey("dbo.Films", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.FilmActorRoles", "FilmTitleId", "dbo.Films");
            DropForeignKey("dbo.FilmActorRoles", "ActorId", "dbo.Actors");
            DropIndex("dbo.ProducerFilms", new[] { "Film_Id" });
            DropIndex("dbo.ProducerFilms", new[] { "Producer_Id" });
            DropIndex("dbo.Films", new[] { "Genre_Id" });
            DropIndex("dbo.FilmActorRoles", new[] { "RoleId" });
            DropIndex("dbo.FilmActorRoles", new[] { "ActorId" });
            DropIndex("dbo.FilmActorRoles", new[] { "FilmTitleId" });
            DropTable("dbo.ProducerFilms");
            DropTable("dbo.Roles");
            DropTable("dbo.Producers");
            DropTable("dbo.Genres");
            DropTable("dbo.Films");
            DropTable("dbo.FilmActorRoles");
            DropTable("dbo.Actors");
        }
    }
}
