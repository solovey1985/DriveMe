using System;
using System.Data.Entity;

namespace DriveMe.Infrastructure
{
    public interface IContext<T> : IDisposable where T : class
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void SetModified(T entity);
    }
}
