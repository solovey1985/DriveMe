using Bigly.DAL.Contexts;
using Bigly.DAL.UnitsOfWork;
using Bigly.Domain.Models;
using Bigly.Infrastructure;

namespace Bigly.DAL.Repositories
{
    public interface ITripRepository:IRepository<Trip> {}

    public class TripRepository:Repository<Trip, TripContext>, ITripRepository
    {
        public TripRepository() : base(new TripUnitOfWork())
        {
        }
    }
}
