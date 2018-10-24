namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomersDatabaseModelsAddressRelatedInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "PostalCode", c => c.String());
            AddColumn("dbo.Customers", "Address", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Customers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "PostalCode");
            AddPrimaryKey("dbo.Customers", "Id");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
