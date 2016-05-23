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
        public DbSet<Driver>  Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; } 
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Trip> tripConfig = modelBuilder.Entity<Trip>();
            tripConfig.HasKey(c => c.Id).HasRequired(x=>x.Route);
            tripConfig.Ignore(e => e.State);
            
            
            modelBuilder.Entity<Location>().HasKey(l => l.Id);
            modelBuilder.Entity<Location>().Ignore(l => l.State);
            modelBuilder.Entity<Location>().Property(p => p.Position.Latitude).HasColumnName("Latitude");
            modelBuilder.Entity<Location>().Property(p => p.Address).HasMaxLength(255);
            modelBuilder.Entity<Location>().Property(p => p.Position.Longitude).HasColumnName("Longitude");
            
            modelBuilder.Entity<Passenger>().Ignore(p => p.Trip).Ignore(p=>p.State);
            modelBuilder.Entity<Driver>().Ignore(p => p.Vehicle).Ignore(p=>p.State);
            modelBuilder.Entity<Vehicle>().Ignore(p=>p.State);
            modelBuilder.Entity<Route>().Ignore(p=>p.State);
            

            modelBuilder.Configurations.Add(tripConfig);
         

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
