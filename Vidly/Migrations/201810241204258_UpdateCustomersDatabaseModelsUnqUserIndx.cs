namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomersDatabaseModelsUnqUserIndx : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "UserId" });
            CreateIndex("dbo.Customers", "UserId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "UserId" });
            CreateIndex("dbo.Customers", "UserId");
        }
    }
}
