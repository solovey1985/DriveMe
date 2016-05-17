namespace DriveMe.DAL.Migrations.Trip
{
    using System.Data.Entity.Migrations;
    
    public partial class nullabledates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trips", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Trips", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trips", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Trips", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
