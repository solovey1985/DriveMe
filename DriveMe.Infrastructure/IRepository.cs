using System;
using System.Collections.Generic;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Infrastructure
{
    public interface IRepository<T> where T:IAggregateRoot
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id); 
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool DeleteById(Guid id);
    }
}
