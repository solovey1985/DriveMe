using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase, IAggregateRoot
    {
        public IContext<T> Dal { get; set; }

        protected IDbSet<T> _dbSet => _context.Set<T>();
        private DbContext _context;

        public RepositoryBase(DbContext cntx)
        {
            _context = cntx;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id == id);
        }

        public bool Insert(T entity)
        {
            _dbSet.Add(entity);
            return CommitChanges();
        }

        public bool Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return CommitChanges();
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return CommitChanges();
        }

        public bool DeleteById(Guid id)
        {
            T entity = _dbSet.FirstOrDefault(e => e.Id == id);
            if (entity == null) throw new ObjectNotFoundException($"Entity with id = {id} not found.");
            _dbSet.Remove(entity);

            return CommitChanges();
        }

        private bool CommitChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException();
            }
        }
    }
}
