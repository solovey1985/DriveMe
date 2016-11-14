﻿using System.Data.Entity;

namespace Bigly.DAL.Contexts
{
   

    public class BaseDbContext<IContext> : DbContext where IContext : DbContext
    {

        static BaseDbContext(){Database.SetInitializer<IContext>(null);}

        protected BaseDbContext() : base("name=BiglyEntity")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
        }
    }
}
