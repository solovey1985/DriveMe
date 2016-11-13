using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bigly.Domain.Models;

namespace Bigly.API.ApiServices.Interfaces
{
    public interface ISalaryService
    {
        void BatchUpdate(List<Salary> salariesToUpdate);
        IEnumerable<Salary> GetPerMonthByEmloyeeId(int employeeId);
        void Update(Salary salaryToUpdate);
        IEnumerable<Salary> GetPerMonth();
    }
}
