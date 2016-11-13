using Bigly.DAL.Contexts;
using Bigly.Domain.Models;
using Bigly.Infrastructure;

namespace Bigly.DAL.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
    }
    public class UserRepository:Repository<User, UserContext>, IUserRepository
    {
        public UserRepository() : base()
        { }
        public UserRepository(IUnitOfWork<UserContext> unitOfWork) : base(unitOfWork)
        {
        }
    }

    
}
