using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.DAL.Contexts
{
    public class BaseDbContext<TContext>: DbContext where TContext:DbContext
    {
        static BaseDbContext(){System.Data.Entity.Database.SetInitializer<TContext>(null);} 

        protected BaseDbContext():base("name=DriveMeEntity") {}
    }
}
