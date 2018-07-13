namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduseridtoreference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "AspNetUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "AspNetUserId");
        }
    }
}
