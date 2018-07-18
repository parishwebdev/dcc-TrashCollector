namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcustomerprops : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerSchedules", "DayId", "dbo.Days");
            DropForeignKey("dbo.Customers", "CustomerScheduleId", "dbo.CustomerSchedules");
            DropIndex("dbo.Customers", new[] { "CustomerScheduleId" });
            DropIndex("dbo.CustomerSchedules", new[] { "DayId" });
            AddColumn("dbo.Customers", "DayId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Pickedup", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "ExtraPickUpDate", c => c.DateTime());
            AddColumn("dbo.Customers", "TempStartDate", c => c.DateTime());
            AddColumn("dbo.Customers", "TempEndDate", c => c.DateTime());
            CreateIndex("dbo.Customers", "DayId");
            AddForeignKey("dbo.Customers", "DayId", "dbo.Days", "DayId", cascadeDelete: true);
            DropColumn("dbo.Customers", "CustomerScheduleId");
            DropTable("dbo.CustomerSchedules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerSchedules",
                c => new
                    {
                        CustomerScheduleId = c.Int(nullable: false, identity: true),
                        DayId = c.Int(nullable: false),
                        Pickedup = c.Boolean(nullable: false),
                        ExtraPickUpDate = c.DateTime(),
                        TempStartDate = c.DateTime(),
                        TempEndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerScheduleId);
            
            AddColumn("dbo.Customers", "CustomerScheduleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "DayId", "dbo.Days");
            DropIndex("dbo.Customers", new[] { "DayId" });
            DropColumn("dbo.Customers", "TempEndDate");
            DropColumn("dbo.Customers", "TempStartDate");
            DropColumn("dbo.Customers", "ExtraPickUpDate");
            DropColumn("dbo.Customers", "Pickedup");
            DropColumn("dbo.Customers", "DayId");
            CreateIndex("dbo.CustomerSchedules", "DayId");
            CreateIndex("dbo.Customers", "CustomerScheduleId");
            AddForeignKey("dbo.Customers", "CustomerScheduleId", "dbo.CustomerSchedules", "CustomerScheduleId", cascadeDelete: true);
            AddForeignKey("dbo.CustomerSchedules", "DayId", "dbo.Days", "DayId", cascadeDelete: true);
        }
    }
}
