namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "CreationDate", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Movies", "CreationDate");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
