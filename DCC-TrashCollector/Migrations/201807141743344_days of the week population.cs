namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class daysoftheweekpopulation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        DayChoosen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DayId);



        }
        
        public override void Down()
        {
            DropTable("dbo.Days");
        }
    }
}
