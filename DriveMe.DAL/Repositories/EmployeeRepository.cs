using Bigly.DAL.Contexts;
using Bigly.DAL.UnitsOfWork;
using Bigly.Domain.Models;
using Bigly.Infrastructure;

namespace Bigly.DAL.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee> {}

    public class EmployeeRepository:Repository<Employee, EmployeeContext>, IEmployeeRepository
    {
        public EmployeeRepository() : base(new EmployeeUnitOfWork())
        {
        }
    }
}
