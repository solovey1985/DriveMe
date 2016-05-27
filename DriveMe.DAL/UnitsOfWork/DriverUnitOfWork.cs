using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.DAL.Contexts;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DAL;

namespace DriveMe.DAL.UnitsOfWork
{
    public class DriverUnitOfWork:IUnitOfWork<TripContext>
    {
        public TripContext Context { get; }
        public DriverUnitOfWork()
        {
            Context = new TripContext();
        }

        public int Save()
        {
            Context.ApplyStateChanges();
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
