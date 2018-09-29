namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CustomerUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AddColumn("dbo.Customers", "Handler", c => c.String());
            AddColumn("dbo.Customers", "Sex", c => c.String());
            AddColumn("dbo.Customers", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CountryCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            DropColumn("dbo.Customers", "CountryCode");
            DropColumn("dbo.Customers", "PhoneNumber");
            DropColumn("dbo.Customers", "Sex");
            DropColumn("dbo.Customers", "Handler");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id");
        }
    }
}
