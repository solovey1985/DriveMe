using Bigly.DAL.Contexts;

namespace Bigly.DAL.UnitsOfWork
{
    public interface IUserUnitOfWork
    {
    }

    public class UserUnitOfWork:UnitOfWork<UserContext>, IUserUnitOfWork
    {

    }
}
