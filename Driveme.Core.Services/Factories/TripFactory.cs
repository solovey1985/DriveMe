using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.Domain.Models;
using Driveme.Domain.Services.Factories;
using DriveMe.Infrastructure;

namespace Driveme.Domain.Services.Factories
{
    public interface ITripFactory: IBaseFactory<Trip>
    {
        Trip CreateWithRoute(Route route);
    }
    public class TripFactory : BaseFactory<Trip>, ITripFactory
    {
       public Trip CreateWithRoute(Route route)
        {
            Create();
            entity.Route = route;
            return entity;
        }
    }
}
