using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using DriveMe.Domain.Models;

namespace DriveMe.DAL.Contexts
{
    public class TripContext:BaseDbContext<TripContext>
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Route> Routes { get; set; } 
        //public DbSet<Location> Locations { get; set; }
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Trip> tripConfig = modelBuilder.Entity<Trip>();
            tripConfig.HasKey(c => c.Id);
            //tripEntityConfig.Ignore(e => e.Passangers);
            //tripEntityConfig.Ignore(e => e.Route);
            //tripEntityConfig.Ignore(e => e.Driver);
            //tripEntityConfig.Ignore(e => e.Vehicle);
            //tripEntityConfig.HasMany(x => x.Passangers).WithRequired().HasForeignKey(v=>v.Id).WillCascadeOnDelete(false);

          //  modelBuilder.Entity<Location>().Ignore(l => l.Position);
            modelBuilder.Entity<Location>().HasKey(l => l.Id);
            modelBuilder.Entity<Location>().Property(p => p.Position.Latitude).HasColumnName("Latitude");
            modelBuilder.Entity<Location>().Property(p => p.Address).HasMaxLength(255);
            modelBuilder.Entity<Location>().Property(p => p.Position.Longitude).HasColumnName("Longitude");



            modelBuilder.Entity<Passenger>().Ignore(p => p.Trip);
            modelBuilder.Entity<Driver>().Ignore(p => p.Vehicle);

            modelBuilder.Configurations.Add(tripConfig);
         

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
