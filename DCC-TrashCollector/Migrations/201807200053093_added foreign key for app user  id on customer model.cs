namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeyforappuseridoncustomermodel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropColumn("dbo.Customers", "AspNetUserId");
            RenameColumn(table: "dbo.Customers", name: "User_Id", newName: "AspNetUserId");
            AlterColumn("dbo.Customers", "AspNetUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "AspNetUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "AspNetUserId" });
            AlterColumn("dbo.Customers", "AspNetUserId", c => c.String());
            RenameColumn(table: "dbo.Customers", name: "AspNetUserId", newName: "User_Id");
            AddColumn("dbo.Customers", "AspNetUserId", c => c.String());
            CreateIndex("dbo.Customers", "User_Id");
        }
    }
}
