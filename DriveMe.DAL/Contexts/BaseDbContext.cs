using System.Data.Entity;

namespace DriveMe.DAL.Contexts
{
   

    public class BaseDbContext<IContext> : DbContext where IContext : DbContext
    {

        static BaseDbContext(){System.Data.Entity.Database.SetInitializer<IContext>(null);}

        protected BaseDbContext() : base("name=DriveMeEntity")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
        }
    }
}
