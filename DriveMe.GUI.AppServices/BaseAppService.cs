using Driveme.Domain.Services.Factories;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.GUI.AppServices
{
    public interface IBaseAppService
    {
    }

    public abstract class BaseAppService<T> : IBaseAppService where T:Entity, IAggregateRoot, new()
    {
        protected IBaseFactory<T> factory;
        protected IRepository<T> repository;
        protected BaseAppService() { } 
        protected BaseAppService(IBaseFactory<T> factory, IRepository<T> repository)
        {
            this.factory = factory;
            this.repository = repository;
        }
    }
}
