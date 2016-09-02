using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DAL;

namespace DriveMe.DAL.UnitsOfWork
{
    public abstract class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext:DbContext
    {

        public TContext Context { get; }

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
