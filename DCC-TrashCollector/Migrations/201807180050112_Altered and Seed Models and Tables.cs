namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredandSeedModelsandTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ZipId", c => c.Int(nullable: false));
            AlterColumn("dbo.States", "Name", c => c.String(nullable: false, maxLength: 2));
            CreateIndex("dbo.Employees", "ZipId");
            AddForeignKey("dbo.Employees", "ZipId", "dbo.ZipCodes", "ZipCodeId", cascadeDelete: true);
            DropColumn("dbo.Employees", "AssignZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "AssignZipCode", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "ZipId", "dbo.ZipCodes");
            DropIndex("dbo.Employees", new[] { "ZipId" });
            AlterColumn("dbo.States", "Name", c => c.String());
            DropColumn("dbo.Employees", "ZipId");
        }
    }
}
