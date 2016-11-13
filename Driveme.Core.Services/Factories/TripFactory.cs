using Bigly.Domain.Models;

namespace Driveme.Domain.Services.Factories
{
    public interface ISalaryFactory: IBaseFactory<Salary>
    {
        
    }
    public class TripFactory : BaseFactory<Salary>, ISalaryFactory
    {
      
    }
}
