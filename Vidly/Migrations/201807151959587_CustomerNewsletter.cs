namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CustomerNewsletter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Newsletter", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "Newsletter");
        }
    }
}
