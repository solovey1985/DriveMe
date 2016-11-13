using Bigly.DAL.Contexts;

namespace Bigly.DAL.UnitsOfWork
{
    public interface ISalaryUnitOfWork
    {
    }

    public class SalaryUnitOfWork:UnitOfWork<SalaryContext>, ISalaryUnitOfWork
    {

    }
}
