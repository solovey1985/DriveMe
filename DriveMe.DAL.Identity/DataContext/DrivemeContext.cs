using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.DAL.Identity.Models;

namespace DriveMe.DAL.Identity
{
    public class DrivemeContext:DbContext
    {
        public DrivemeContext():base("name=DrivemeEntity")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
           //throw new UnintentionalCodeFirstException();
        }
         
        public virtual  DbSet<User> Users { get; set; }
        public virtual  DbSet<Vehicle> Vehicles { get; set; }
        public virtual  DbSet<Route> Routes { get; set; }
    }

}
