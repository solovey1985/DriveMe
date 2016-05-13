namespace DriveMe.DAL.Migrations.User
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        HomeAddress = c.String(),
                        WorkAddress = c.String(),
                        FavouriteAddress = c.String(),
                        VehicleId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
