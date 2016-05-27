using System;
using System.Data.Entity;

namespace DriveMe.Infrastructure
{
    public interface IUnitOfWork<TContext>:IDisposable where TContext:DbContext
    {
        int Save();
        TContext Context { get; }

    }
}
