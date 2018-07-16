namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Days", "DayChoosen", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Days", "DayChoosen", c => c.Int(nullable: false));
        }
    }
}
