using System.Data.Entity;
using Bigly.Domain.Models;

namespace Bigly.DAL.Contexts
{
    public class EmployeeContext:BaseDbContext<EmployeeContext>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Salary> Salaries { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Employee>().Ignore(t => t.State);
            modelBuilder.Entity<Employee>().HasOptional(e => e.Salries);
            modelBuilder.Entity<Employee>().HasMany<Salary>(p => p.Salries);
            
            modelBuilder.Entity<Rate>().HasKey(r => r.Id);
            modelBuilder.Entity<Rate>().Ignore(p => p.State);

            modelBuilder.Entity<Salary>().Ignore(p=>p.State);
            

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
