namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gotridoftest : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TestCustomers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestCustomers",
                c => new
                    {
                        TestCustId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TestCustId);
            
        }
    }
}
