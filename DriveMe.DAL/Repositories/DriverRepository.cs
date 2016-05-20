using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.DAL.Contexts;
using DriveMe.Domain.Models;
using DriveMe.Infrastructure;

namespace DriveMe.DAL.Repositories
{
    public interface IDriverRepository
    {
    }

    public class DriverRepository:RepositoryBase<Driver>, IDriverRepository
    {
        public DriverRepository(TripContext cntx) : base(cntx)
        {
        }

    }
}
