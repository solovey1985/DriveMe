using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using DriveMe.Domain.Models;

namespace DriveMe.DAL.Contexts
{
    public class TripContext:BaseDbContext<TripContext>
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Route> Routes { get; set; } 
        public DbSet<Location> Locations { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Trip>().HasKey(t => t.Id);
            modelBuilder.Entity<Trip>().Ignore(t => t.State);
            modelBuilder.Entity<Trip>().HasOptional(t=>t.Route);
            modelBuilder.Entity<Trip>().HasMany<User>(p => p.Passengers);
            
            modelBuilder.Entity<Location>().HasKey(l => l.Id);
            modelBuilder.Entity<Location>().Property(p => p.Position.Latitude).HasColumnName("Latitude");
            modelBuilder.Entity<Location>().Property(p => p.Address).HasMaxLength(255);
            modelBuilder.Entity<Location>().Property(p => p.Position.Longitude).HasColumnName("Longitude");
         
            modelBuilder.Entity<Vehicle>().Ignore(p=>p.State);
            modelBuilder.Entity<User>().Ignore(t => t.State);
            modelBuilder.Entity<Route>().Ignore(p=>p.State);
            modelBuilder.Entity<Location>().Ignore(l => l.State);

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
