using DriveMe.DAL.Contexts;
using DriveMe.DAL.UnitsOfWork;
using DriveMe.Domain.Models;
using DriveMe.Infrastructure;

namespace DriveMe.DAL.Repositories
{
    public interface ITripRepository:IRepository<Trip> {}

    public class TripRepository:Repository<Trip, TripContext>, ITripRepository
    {
        public TripRepository(ITripUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
