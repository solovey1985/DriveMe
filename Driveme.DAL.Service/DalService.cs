using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DriveMe.DAL.Identity;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Activation;

namespace DriveMe.DAL.Service
{
    public interface IDalService<T> : IDisposable where T : class
    {
        T Get(int id);
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        void Refresh();
    }
    public class DalService<T>: IDalService<T> where T:class 
    {
        [Inject]
        public IContext<T> Dal { get; set; }

        protected IDbSet<T> Context => Dal.Set<T>();
        public virtual void Dispose()
        {
           
        }

        public virtual T Get(int id)
        {
            T item = null;
            using (var db = new DrivemeContext())
            {
                IQueryable<T> dbQuery = db.Set<T>();
            }
            return Context.Find(id);
        }

        public virtual IQueryable<T> Get()
        {
            return Context.AsQueryable();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Where(predicate);
        }

        public virtual T Add(T entity)
        {
            //Dal.Set<T>().Add;
            T entry = Context.Add(entity);
            ApplyChanges();
            return entry;
        }

        public virtual bool Update(T entity)
        {
          if(entity == null)
                throw new NullReferenceException("Entity is null");
            if (!Context.Local.Contains(entity))
            {
                Context.Attach(entity);
            }
            Dal.SetModified(entity);
            return ApplyChanges();
        }

        public virtual bool Delete(T entity)
        {
            Context.Remove(entity);
            return ApplyChanges();
        }

        public virtual bool Delete(int id)
        {
            T entity = Context.Find(id);
            if (entity == null)
                return false;
            Context.Remove(entity);
            return ApplyChanges();
        }

        public virtual void Refresh()
        {
            throw new NotImplementedException();
        }

        protected bool ApplyChanges()
        {
            try
            {
                Dal.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
