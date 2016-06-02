using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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
    public interface IDriverService
    {
        Guid DriverId { get; set; }
        Guid CreateDriver(User driver);
        void CreateTrip(DateTime start);
        void CreateRoute(Location startLocation, Location endLocation);
        Guid AddRoute(Route route, Guid tripId);
        void AddWaypoints(Guid routeId, List<Waypoint> waypoints);
        IEnumerable<Trip> GetAllTrips();
        User GetDriverById(Guid id);
        IEnumerable<User> GetAllDrivers();
        Guid Update(User driver);
    }

    public class DriverService:BaseAppService<Trip>, IDriverService
    {
        #region Private Members
        private Guid driverId;
      
        IUserRepository driverRepo;
        IUserUnitOfWork userUnitOfWork;
        #endregion

        #region Override Members

        #endregion

        #region Public Members
        public Guid DriverId { get { return driverId; } set { driverId = value; } }
        #endregion
        

        public DriverService(   IUserRepository userRepository,  
                                IUserUnitOfWork userUnitOfWork, 
                                ITripFactory tripFactory, 
                                ITripRepository tripRepository
                            ) : base(tripFactory, tripRepository)
        {
            
            driverRepo = userRepository;
            this.userUnitOfWork = userUnitOfWork;
        }

        public DriverService(   IUserRepository userRepository, 
                                IUserUnitOfWork userUnitOfWork, 
                                ITripFactory tripFactory, 
                                ITripRepository tripRepository, 
                                Guid driverId
                            ) : base(tripFactory, tripRepository)
        {
            driverRepo = userRepository;
            this.userUnitOfWork = userUnitOfWork;
            this.driverId = driverId;
        }

        public Guid CreateDriver(User driver)
        {
            User newDriver = new UserFactory().Create(driver);
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

        public User GetDriverById(Guid id)
        {
            return driverRepo.GetById(id);
        }

        public IEnumerable<User> GetAllDrivers()
        {
            return driverRepo.GetAll();
        }

        public Guid Update(User driver)
        {
            driverRepo.Update(driver);
            return driver.Id;
        }
    }
}
