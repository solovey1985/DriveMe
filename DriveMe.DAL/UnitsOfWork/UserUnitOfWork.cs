using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.DAL.Contexts;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DAL;

namespace DriveMe.DAL.UnitsOfWork
{
    public interface IUserUnitOfWork
    {
    }

    public class UserUnitOfWork:UnitOfWork<UserContext>, IUserUnitOfWork
    {

    }
}
