using DriveMe.GUI.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DriveMe.GUI.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DriveMe.GUI.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DriveMe.GUI.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(DriveMe.GUI.Web.Models.ApplicationDbContext context)
        {   //Simple approach
           
            context.Roles.AddOrUpdate(r=>r.Name,  
                new IdentityRole {Name = "Admin"}, 
                new IdentityRole("User"), 
                new IdentityRole("SuperAdmin"), 
                new IdentityRole("Visitor")
                );
            /* 
            //With RoleManger
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            string[] roles = new[] {"Admin", "SuperAdmin", "User", "Visitor"};
            IdentityResult roleResult;
            foreach (string role in roles)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleResult = roleManager.Create(new IdentityRole(role));
                }
            }
            */
        }
    }
}
