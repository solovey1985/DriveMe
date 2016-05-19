using Driveme.Domain.Services.Factories;
using DriveMe.Infrastructure;

namespace DriveMe.GUI.AppServices
{
    public abstract class BaseAppService<T> where T:EntityBase, new()
    {
        protected BaseFactory<T> factory;

        public BaseAppService(BaseFactory<T> factory)
        {
            this.factory = factory;
        }
    }
}
