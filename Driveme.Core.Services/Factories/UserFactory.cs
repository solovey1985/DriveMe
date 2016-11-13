using Bigly.Domain.Models;

namespace Driveme.Domain.Services.Factories
{
    public interface IUserFactory:IBaseFactory<User> { }
    public class UserFactory:BaseFactory<User>, IUserFactory
    {
    }
}
