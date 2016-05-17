using System.Data.Entity;
using DriveMe.Domain.Models;

namespace DriveMe.DAL.Contexts
{
    public class TripContext:BaseDbContext<TripContext>
    {
        public DbSet<Trip> Trips { get; set; } 

    }
}
