using System.Data.Entity;
using Bigly.Domain.Models;

namespace Bigly.DAL.Contexts
{
    public class UserContext:BaseDbContext<UserContext>
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<User>().Ignore(u => u.State);
        }
    }
}
