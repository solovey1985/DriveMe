namespace DriveMe.DAL.Migrations.Trip
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        HomeAddress = c.String(),
                        WorkAddress = c.String(),
                        FavouriteAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Address = c.String(maxLength: 255),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Route_Id = c.Guid(),
                        Route_Id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id1)
                .Index(t => t.Route_Id)
                .Index(t => t.Route_Id1);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TripId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        HomeAddress = c.String(),
                        WorkAddress = c.String(),
                        FavouriteAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        EndPoint_Id = c.Guid(),
                        StartPoint_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.EndPoint_Id)
                .ForeignKey("dbo.Locations", t => t.StartPoint_Id)
                .Index(t => t.EndPoint_Id)
                .Index(t => t.StartPoint_Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        DriverId = c.Guid(nullable: false),
                        VehicleId = c.Guid(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        Route_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.Route_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId)
                .Index(t => t.Route_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Vendor = c.String(),
                        Model = c.String(),
                        Plate = c.String(),
                        Color = c.Int(nullable: false),
                        MaxPassengers = c.Int(nullable: false),
                        MaxWeightKg = c.Int(nullable: false),
                        Driver_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .Index(t => t.Driver_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Trips", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.Passengers", "TripId", "dbo.Trips");
            DropForeignKey("dbo.Trips", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Routes", "StartPoint_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Route_Id1", "dbo.Routes");
            DropForeignKey("dbo.Routes", "EndPoint_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Route_Id", "dbo.Routes");
            DropIndex("dbo.Vehicles", new[] { "Driver_Id" });
            DropIndex("dbo.Trips", new[] { "Route_Id" });
            DropIndex("dbo.Trips", new[] { "VehicleId" });
            DropIndex("dbo.Trips", new[] { "DriverId" });
            DropIndex("dbo.Routes", new[] { "StartPoint_Id" });
            DropIndex("dbo.Routes", new[] { "EndPoint_Id" });
            DropIndex("dbo.Passengers", new[] { "TripId" });
            DropIndex("dbo.Locations", new[] { "Route_Id1" });
            DropIndex("dbo.Locations", new[] { "Route_Id" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Trips");
            DropTable("dbo.Routes");
            DropTable("dbo.Passengers");
            DropTable("dbo.Locations");
            DropTable("dbo.Drivers");
        }
    }
}
