using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driveme.Domain.Services.Factories;
using DriveMe.DAL.Contexts;
using DriveMe.DAL.Repositories;
using DriveMe.DAL.UnitsOfWork;
using DriveMe.Domain.Models;

namespace DriveMe.GUI.AppServices
{
    public class TripService:BaseAppService<Trip>
    {
        RouteFactory routeFactory;
        public TripService(IBaseFactory<Trip> factory, ITripRepository repository) : base(factory, repository)
        {
            
        }

        public IEnumerable<Trip> GetAll()
        {
            return repository.GetAll();
        }

        public Trip GetById(Guid id)
        {
            return repository.GetById(id);
        }

        public Guid Create(Trip trip)
        {
            trip = factory.Create(trip);
            repository.Insert(trip);
            return trip.Id;

        }

        public Guid Update(Trip trip)
        {
            repository.Update(trip);
            return trip.Id;
        }

        public void DeleteById(Guid id)
        {
            repository.DeleteById(id);
        }

        public void DeleteRoute(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRoute(Route route)
        {
            throw new NotImplementedException();
        }

        public Guid AddRoute(Route route)
        {
            Route newRoute = routeFactory.Create(route);
            Trip trip = repository.GetById(route.TripId.Value);
            trip.Route = newRoute;
            repository.Update(trip);
            return route.Id;
        }

        public Route GetRouteByTripId(Guid tripId)
        {
            throw new NotImplementedException();
        }
    }
}
