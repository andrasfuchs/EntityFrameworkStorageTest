namespace StorageTest.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotesToFilm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 500),
                        Film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Film_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "Film_Id", "dbo.Films");
            DropIndex("dbo.Notes", new[] { "Film_Id" });
            DropTable("dbo.Notes");
        }
    }
}
