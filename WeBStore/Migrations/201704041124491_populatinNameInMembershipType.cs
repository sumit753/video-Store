namespace WeBStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populatinNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name='Pay As You Go' WHERE DurationInMonth=0 ");
            Sql("Update MembershipTypes SET Name='Monthly' WHERE DurationInMonth=1 ");
            Sql("Update MembershipTypes SET Name='Quaterly' WHERE DurationInMonth=3 ");
            Sql("Update MembershipTypes SET Name='Yearly' WHERE DurationInMonth=12 ");
        }

        public override void Down()
        {
        }
    }
}
