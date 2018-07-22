namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedforignkeythatIjustadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "AspNetUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "AspNetUserId" });
            AlterColumn("dbo.Customers", "AspNetUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "AspNetUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "AspNetUserId");
            AddForeignKey("dbo.Customers", "AspNetUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
