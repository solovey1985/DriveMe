namespace DriveMe.DAL.Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ShortTitle = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        ShortTitle = c.String(maxLength: 20),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlateNumber = c.String(),
                        Model = c.String(),
                        Color = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        ShortTitle = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
            DropTable("dbo.Users");
            DropTable("dbo.Routes");
        }
    }
}
