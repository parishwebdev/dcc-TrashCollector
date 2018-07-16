namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddresses", "State", c => c.String());
            AlterColumn("dbo.CustomerAddresses", "Zip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerAddresses", "Zip", c => c.String());
            DropColumn("dbo.CustomerAddresses", "State");
        }
    }
}
