using Driveme.Domain.Services.Factories;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.GUI.AppServices
{
    public abstract class BaseAppService<T> where T:EntityBase, IAggregateRoot, new()
    {
        protected BaseFactory<T> factory;
        protected IRepository<T> repository; 
        public BaseAppService(BaseFactory<T> factory, IRepository<T> repository)
        {
            this.factory = factory;
            this.repository = repository;
        }
    }
}
