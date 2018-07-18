namespace DCC_TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCustomerAddedCityZipCodeState : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerAddressId", "dbo.CustomerAddresses");
            DropIndex("dbo.Customers", new[] { "CustomerAddressId" });
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.ZipCodes",
                c => new
                    {
                        ZipCodeId = c.Int(nullable: false, identity: true),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZipCodeId);
            
            AddColumn("dbo.Customers", "AddressLine", c => c.String());
            AddColumn("dbo.Customers", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ZipId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CityId");
            CreateIndex("dbo.Customers", "ZipId");
            CreateIndex("dbo.Customers", "StateId");
            AddForeignKey("dbo.Customers", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "StateId", "dbo.States", "StateId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "ZipId", "dbo.ZipCodes", "ZipCodeId", cascadeDelete: true);
            DropColumn("dbo.Customers", "CustomerAddressId");
            DropTable("dbo.CustomerAddresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                    {
                        CustomerAddressId = c.Int(nullable: false, identity: true),
                        AddressLine = c.String(),
                        City = c.String(),
                        Zip = c.Int(nullable: false),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.CustomerAddressId);
            
            AddColumn("dbo.Customers", "CustomerAddressId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "ZipId", "dbo.ZipCodes");
            DropForeignKey("dbo.Customers", "StateId", "dbo.States");
            DropForeignKey("dbo.Customers", "CityId", "dbo.Cities");
            DropIndex("dbo.Customers", new[] { "StateId" });
            DropIndex("dbo.Customers", new[] { "ZipId" });
            DropIndex("dbo.Customers", new[] { "CityId" });
            DropColumn("dbo.Customers", "StateId");
            DropColumn("dbo.Customers", "ZipId");
            DropColumn("dbo.Customers", "CityId");
            DropColumn("dbo.Customers", "AddressLine");
            DropTable("dbo.ZipCodes");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            CreateIndex("dbo.Customers", "CustomerAddressId");
            AddForeignKey("dbo.Customers", "CustomerAddressId", "dbo.CustomerAddresses", "CustomerAddressId", cascadeDelete: true);
        }
    }
}
