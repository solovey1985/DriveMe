using System.Data.Entity.Migrations;
using Bigly.DAL.Contexts;

namespace Bigly.DAL.Migrations.User
{
    internal sealed class UserConfiguration : DbMigrationsConfiguration<UserContext>
    {
        public UserConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\User";
        }
        

        protected override void Seed(UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
