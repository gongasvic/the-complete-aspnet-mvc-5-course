namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserHandler : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Handler", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Handler", c => c.String());
        }
    }
}
