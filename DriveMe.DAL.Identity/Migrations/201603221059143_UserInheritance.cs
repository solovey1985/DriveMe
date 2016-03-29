namespace DriveMe.DAL.Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInheritance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "LastLoginDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "IsOnline", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "Title");
            DropColumn("dbo.Users", "ShortTitle");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsOnline");
            DropColumn("dbo.Users", "LastLoginDate");
            DropColumn("dbo.Users", "Birthday");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
