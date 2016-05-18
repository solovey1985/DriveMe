namespace DriveMe.DAL.Migrations.Trip
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTripContext : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Address = c.String(maxLength: 255),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                      
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Address, unique:true);
                
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        DriverId = c.Guid(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                        RouteId = c.Guid(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId)
                .Index(t => t.RouteId);
            
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
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Vendor = c.String(),
                        Model = c.String(),
                        Plate = c.String(),
                        Color = c.Int(nullable: false),
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
            DropForeignKey("dbo.Trips", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Passengers", "TripId", "dbo.Trips");
            DropForeignKey("dbo.Trips", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Routes", "StartPoint_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Route_Id1", "dbo.Routes");
            DropForeignKey("dbo.Routes", "EndPoint_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Route_Id", "dbo.Routes");
            DropIndex("dbo.Vehicles", new[] { "Driver_Id" });
            DropIndex("dbo.Passengers", new[] { "TripId" });
            DropIndex("dbo.Trips", new[] { "RouteId" });
            DropIndex("dbo.Trips", new[] { "VehicleId" });
            DropIndex("dbo.Trips", new[] { "DriverId" });
            DropIndex("dbo.Locations", new[] { "Route_Id1" });
            DropIndex("dbo.Locations", new[] { "Route_Id" });
            DropIndex("dbo.Routes", new[] { "StartPoint_Id" });
            DropIndex("dbo.Routes", new[] { "EndPoint_Id" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Passengers");
            DropTable("dbo.Drivers");
            DropTable("dbo.Trips");
            DropTable("dbo.Locations");
            DropTable("dbo.Routes");
        }
    }
}
