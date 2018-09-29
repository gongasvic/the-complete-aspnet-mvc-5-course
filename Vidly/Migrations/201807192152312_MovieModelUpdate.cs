namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Description", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Movies", "AvailableUnits", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "AvailableUnits");
            DropColumn("dbo.Movies", "Description");
        }
    }
}
