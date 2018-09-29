namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class MovieGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                {
                    Id = c.Byte(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Movies", "MovieGenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenreId");
            AddForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenreId" });
            DropColumn("dbo.Movies", "MovieGenreId");
            DropTable("dbo.MovieGenres");
        }
    }
}
