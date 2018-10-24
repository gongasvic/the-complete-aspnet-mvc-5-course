namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomersDatabaseModelUSERIDNotKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "Id");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Customers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
