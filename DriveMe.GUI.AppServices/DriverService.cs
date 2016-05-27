using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driveme.Domain.Services.Factories;
using DriveMe.DAL.Contexts;
using DriveMe.DAL.Repositories;
using DriveMe.Domain.Models;

namespace DriveMe.GUI.AppServices
{
    public class DriverService:BaseAppService<Trip>
    {
        #region Private Members
        private Guid driverId;
        
        DriverRepository driverRepo = new DriverRepository(new TripContext());
        #endregion

        #region Override Members

        #endregion

        #region Public Members
        public Guid DriverId { get { return driverId; } set { driverId = value; } }
        #endregion



        public DriverService() : base(new TripFactory(), new TripRepository())
        {
            driverId = Guid.NewGuid();
            
        }

        public DriverService(Guid driverId) : base(new TripFactory(), new TripRepository())
        {
            this.driverId = driverId;
        }

        public Guid CreateDriver(Driver driver)
        {
            Driver newDriver = new DriverFactory().Create(driver);
            driverRepo.Insert(newDriver);

            return newDriver.Id;
        }

        public void CreateTrip(DateTime start)
        {
            Trip trip = factory.Create();
          
            repository.Insert(trip);
        }

        public void CreateRoute(Location startLocation, Location endLocation)
        {}

        public Guid AddRoute(Route route, Guid tripId)
        {
            Trip trip = repository.GetById(tripId);

            if (trip==null)
                throw new ObjectNotFoundException($"Trip with ID {tripId} not found");

            Route newRoute = new RouteFactory().Create(route);
            trip.Route = newRoute;
            repository.Update(trip);

            return newRoute.Id;

        }

        public void AddWaypoints(Guid routeId, List<Waypoint> waypoints)
        {}


        public IEnumerable<Trip> GetAllTrips()
        {
            return repository.GetAll();
        }

        public Driver GetDriverById(Guid id)
        {
            return driverRepo.GetById(id);
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            return driverRepo.GetAll();
        }

        public Guid Update(Driver driver)
        {
            driverRepo.Update(driver);
            return driver.Id;
        }
    }
}
