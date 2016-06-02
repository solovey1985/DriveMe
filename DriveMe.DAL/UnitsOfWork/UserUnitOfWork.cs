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

    public class UserUnitOfWork:IUnitOfWork<UserContext>, IUserUnitOfWork
    {
        public UserContext Context { get; }
        public UserUnitOfWork()
        {
            Context = new UserContext();
        }

        public int Save()
        {
            Context.ApplyStateChanges();
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
