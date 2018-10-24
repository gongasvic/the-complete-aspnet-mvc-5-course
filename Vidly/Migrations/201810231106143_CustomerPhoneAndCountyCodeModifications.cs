namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerPhoneAndCountyCodeModifications : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.Int());
            AlterColumn("dbo.Customers", "CountryCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CountryCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
