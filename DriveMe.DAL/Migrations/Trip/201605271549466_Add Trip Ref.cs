namespace DriveMe.DAL.Migrations.Trip
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTripRef : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "TripId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routes", "TripId");
        }
    }
}
