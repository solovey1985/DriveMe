using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.DAL.Contexts;
using DriveMe.Domain.Models;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DAL;

namespace DriveMe.DAL.UnitsOfWork
{
    public interface ITripUnitOfWork : IUnitOfWork<TripContext>
    {
    }
    public class TripUnitOfWork: UnitOfWork<TripContext>,ITripUnitOfWork
    {
        public TripUnitOfWork(TripContext context) : base(context)
        {
        }
    }

   
}
