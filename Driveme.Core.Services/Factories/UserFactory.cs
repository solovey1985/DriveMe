using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.Domain.Models;

namespace Driveme.Domain.Services.Factories
{
    public interface IUserFactory:IBaseFactory<User> { }
    public class UserFactory:BaseFactory<User>, IUserFactory
    {
    }
}
