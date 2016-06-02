using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.DAL.Contexts;
using DriveMe.Domain.Models;
using DriveMe.Infrastructure;

namespace DriveMe.DAL.Repositories
{
    public interface IUserRepository: IRepositoryBase<User>
    {
    }
    public class UserRepository:RepositoryBase<User, UserContext>, IUserRepository
    {
        public UserRepository() : base()
        { }
        public UserRepository(IUnitOfWork<UserContext> unitOfWork) : base(unitOfWork)
        {
        }
    }

    
}
