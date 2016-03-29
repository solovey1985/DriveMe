namespace DriveMe.DAL.Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SingleUserInheritance : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Users");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        IsOnline = c.Boolean(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            
        }
        
        public override void Down()
        {
           DropTable("dbo.Users");
        }
    }
}
