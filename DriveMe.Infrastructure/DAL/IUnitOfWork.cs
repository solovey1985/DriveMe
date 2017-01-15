using System;
using System.Data.Entity;

namespace DriveMe.Infrastructure
{
    public interface IUnitOfWork<TContext>:IDisposable where TContext:DbContext
    {
        bool Save();
        TContext Context { get; }

    }
}
