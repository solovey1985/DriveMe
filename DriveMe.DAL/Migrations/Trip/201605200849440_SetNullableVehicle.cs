namespace DriveMe.DAL.Migrations.Trip
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNullableVehicle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trips", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Trips", new[] { "VehicleId" });
            AlterColumn("dbo.Trips", "VehicleId", c => c.Guid());
            CreateIndex("dbo.Trips", "VehicleId");
            AddForeignKey("dbo.Trips", "VehicleId", "dbo.Vehicles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Trips", new[] { "VehicleId" });
            AlterColumn("dbo.Trips", "VehicleId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Trips", "VehicleId");
            AddForeignKey("dbo.Trips", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
    }
}
