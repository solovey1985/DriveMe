using System.Data.Entity;
using Bigly.Infrastructure;
using Bigly.Infrastructure.DAL;

namespace Bigly.DAL.UnitsOfWork
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
           
        }
    }
}
