using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.Domain.Models;

namespace DriveMe.DAL.Contexts
{
    public class UserContext:BaseDbContext<UserContext>
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Driver> Drivers { get; set; } 
        public DbSet<Passenger> Passengers { get; set; } 
    }
}
