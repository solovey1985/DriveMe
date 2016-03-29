using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.DAL.Identity
{
    public interface IContext<T>: IDisposable where T:class
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void SetModified(T entity);
    }

    public class Context<T> : DrivemeContext, IContext<T> where T : class
    {
        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SetModified(T entity)
        {
            var entry = Entry(entity);
            entry.State = EntityState.Modified;
        }

        public Context()
        {
            Configuration.ProxyCreationEnabled = true;
        }

    }
}
