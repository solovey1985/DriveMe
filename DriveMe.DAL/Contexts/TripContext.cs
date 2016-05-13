using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.Domain.Models;

namespace DriveMe.DAL.Contexts
{
    public class TripContext:BaseDbContext<TripContext>
    {
        public DbSet<Trip> Trips { get; set; } 

    }
}
