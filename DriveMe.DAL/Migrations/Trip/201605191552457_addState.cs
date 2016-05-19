namespace DriveMe.DAL.Migrations.Trip
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "MaxPassengers", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "MaxWeightKg", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "MaxWeightKg");
            DropColumn("dbo.Vehicles", "MaxPassengers");
        }
    }
}
