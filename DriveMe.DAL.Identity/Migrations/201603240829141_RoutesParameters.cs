namespace DriveMe.DAL.Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoutesParameters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "DriverId");
            AddForeignKey("dbo.Vehicles", "DriverId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Users");
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropColumn("dbo.Vehicles", "DriverId");
        }
    }
}
