using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.Infrastructure
{
    public interface IRepository<T> where T:EntityBase
    {
        IEnumerable<T> GetAll();
        T GetById(int id); 
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool DeleteById(int id);
    }
}
