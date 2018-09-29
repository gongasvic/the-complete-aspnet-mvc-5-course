namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UserDatOfBirth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AddColumn("dbo.Customers", "dob", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id");
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "dob");
        }
    }
}
