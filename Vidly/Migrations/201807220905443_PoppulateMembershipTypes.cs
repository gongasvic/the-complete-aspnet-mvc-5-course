namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PoppulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes (Id, Fee, Name, NumMonths, Discount) values (1,0,\'Free\',0,0)");
            Sql("insert into MembershipTypes (Id, Fee, Name, NumMonths, Discount) values (2,30,\'Monthly\',1,10)");
            Sql("insert into MembershipTypes (Id, Fee, Name, NumMonths, Discount) values (3,90,\'Quarterly\',3,15)");
            Sql("insert into MembershipTypes (Id, Fee, Name, NumMonths, Discount) values (4,120,\'Semesterly\',6,20)");
            Sql("insert into MembershipTypes (Id, Fee, Name, NumMonths, Discount) values (5,300,\'Anual\',12,35)");
        }

        public override void Down()
        {
            Sql("delete MembershipTypes");
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
