namespace DriveMe.DAL.Migrations.Trip
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Routes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        TripId = c.Guid(),
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
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        Driver_Id = c.Guid(),
                        Route_Id = c.Guid(),
                        Vehicle_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Driver_Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Driver_Id)
                .Index(t => t.Route_Id)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Login = c.String(),
                        Email = c.String(),
                        HomeAddress = c.String(),
                        WorkAddress = c.String(),
                        FavouriteAddress = c.String(),
                        Role = c.Int(nullable: false),
                        Trip_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trips", t => t.Trip_Id)
                .Index(t => t.Trip_Id);
            
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
                .ForeignKey("dbo.Users", t => t.Driver_Id)
                .Index(t => t.Driver_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Driver_Id", "dbo.Users");
            DropForeignKey("dbo.Trips", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.Users", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.Trips", "Driver_Id", "dbo.Users");
            DropForeignKey("dbo.Routes", "StartPoint_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Route_Id1", "dbo.Routes");
            DropForeignKey("dbo.Routes", "EndPoint_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Route_Id", "dbo.Routes");
            DropIndex("dbo.Vehicles", new[] { "Driver_Id" });
            DropIndex("dbo.Users", new[] { "Trip_Id" });
            DropIndex("dbo.Trips", new[] { "Vehicle_Id" });
            DropIndex("dbo.Trips", new[] { "Route_Id" });
            DropIndex("dbo.Trips", new[] { "Driver_Id" });
            DropIndex("dbo.Routes", new[] { "StartPoint_Id" });
            DropIndex("dbo.Routes", new[] { "EndPoint_Id" });
            DropIndex("dbo.Locations", new[] { "Route_Id1" });
            DropIndex("dbo.Locations", new[] { "Route_Id" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Users");
            DropTable("dbo.Trips");
            DropTable("dbo.Routes");
            DropTable("dbo.Locations");
        }
    }
}
