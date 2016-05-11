using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.Infrastructure
{
    public interface IRepository<T> where T:EntityBase
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
