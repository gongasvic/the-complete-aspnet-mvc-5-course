namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerUserRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserId", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "ApplicationUser_Id");
            AddForeignKey("dbo.Customers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Customers", "ApplicationUser_Id");
            DropColumn("dbo.Customers", "UserId");
        }
    }
}
