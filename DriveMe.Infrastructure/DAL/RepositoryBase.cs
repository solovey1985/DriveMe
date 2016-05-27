using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Infrastructure
{
    public class RepositoryBase<T, TContext> : IRepository<T> where T : EntityBase, IAggregateRoot where TContext:DbContext
    {
        public IContext<T> Dal { get; set; }
        private IUnitOfWork<TContext> _unitOfWork;
        protected IDbSet<T> _dbSet => _context.Set<T>();
        private DbContext _context;

        public RepositoryBase(IUnitOfWork<TContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = unitOfWork.Context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public virtual T GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual bool Insert(T entity)
        {
            _dbSet.Add(entity);
            return CommitChanges();
        }

        public virtual bool Update(T entity)
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

        public virtual bool DeleteById(Guid id)
        {
            T entity = _dbSet.FirstOrDefault(e => e.Id == id);
            if (entity == null) throw new ObjectNotFoundException($"Entity with id = {id} not found.");
            _dbSet.Remove(entity);

            return CommitChanges();
        }

        private bool CommitChanges()
        {
            return _unitOfWork.Save()>0;
        }
    }
}
