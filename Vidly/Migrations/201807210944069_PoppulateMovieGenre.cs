namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PoppulateMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MovieGenres ON");
            Sql("insert into MovieGenres (Id,Name) values (1,\'Comedy\')");
            Sql("insert into MovieGenres (Id,Name) values (2,\'Action\')");
            Sql("insert into MovieGenres (Id,Name) values (3,\'Horror\')");
            Sql("insert into MovieGenres (Id,Name) values (4,\'Adventure\')");
            Sql("insert into MovieGenres (Id,Name) values (5,\'Crime\')");
            Sql("insert into MovieGenres (Id,Name) values (6,\'Drama\')");
            Sql("insert into MovieGenres (Id,Name) values (7,\'Musical\')");
            Sql("insert into MovieGenres (Id,Name) values (8,\'Science Fiction\')");
            Sql("insert into MovieGenres (Id,Name) values (9,\'War\')");
            Sql("insert into MovieGenres (Id,Name) values (10,\'Western\')");
            Sql("insert into MovieGenres (Id,Name) values (11,\'Historical\')");
            Sql("SET IDENTITY_INSERT MovieGenres OFF");

        }

        public override void Down()
        {
            Sql("delete MovieGenres");
        }
    }
}
