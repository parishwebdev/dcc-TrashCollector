namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerscheduleanddaychanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerSchedules", "DayId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerSchedules", "DayId");
            AddForeignKey("dbo.CustomerSchedules", "DayId", "dbo.Days", "DayId", cascadeDelete: true);
            DropColumn("dbo.CustomerSchedules", "RegPickupDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerSchedules", "RegPickupDate", c => c.Int(nullable: false));
            DropForeignKey("dbo.CustomerSchedules", "DayId", "dbo.Days");
            DropIndex("dbo.CustomerSchedules", new[] { "DayId" });
            DropColumn("dbo.CustomerSchedules", "DayId");
        }
    }
}
