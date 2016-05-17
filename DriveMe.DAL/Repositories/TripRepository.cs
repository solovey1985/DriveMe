using DriveMe.DAL.Contexts;
using DriveMe.Domain.Models;
using DriveMe.Infrastructure;

namespace DriveMe.DAL.Repositories
{
    public interface ITripRepository:IRepository<Trip> {}

    public class TripRepository:RepositoryBase<Trip>, ITripRepository
    {
        public TripRepository(TripContext cntx) : base(cntx)
        {
        }
    }
}
