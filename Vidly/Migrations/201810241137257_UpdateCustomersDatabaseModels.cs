namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomersDatabaseModels : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Customers", "UserId");
            RenameColumn(table: "dbo.Customers", name: "ApplicationUser_Id", newName: "UserId");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Customers", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "UserId");
            CreateIndex("dbo.Customers", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "Id");
            RenameColumn(table: "dbo.Customers", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Customers", "UserId", c => c.String(nullable: false));
            CreateIndex("dbo.Customers", "ApplicationUser_Id");
        }
    }
}
