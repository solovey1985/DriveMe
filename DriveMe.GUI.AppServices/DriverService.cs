﻿using System;
using System.Collections.Generic;
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
        TripRepository tripRepo = new TripRepository(new TripContext());
        DriverRepository driverRepo = new DriverRepository(new TripContext());
        #endregion

        #region Override Members

        #endregion

        #region Public Members
        public Guid DriverId { get { return driverId; } set { driverId = value; } }
        #endregion



        public DriverService() : base(new TripFactory())
        {
            driverId = Guid.NewGuid();
            
        }

        public DriverService(Guid driverId) : base(new TripFactory())
        {
            this.driverId = driverId;
        }

        public Guid CreateDriver(string firstName, string lastname)
        {
            Guid guid = Guid.NewGuid();
            Driver driver = new Driver(guid);
            driver.FirstName = firstName;
            driver.LastName = lastname;
            driverRepo.Insert(driver);
            return guid;
        }

        public void CreateTrip(DateTime start)
        {
            Trip trip = factory.Create();
            trip.DriverId = driverId;

            tripRepo.Insert(trip);
        }

        public void CreateRoute(Location startLocation, Location endLocation)
        { }

        public void AddRoute(Guid tripId, Route route)
        {}

        public void AddWaypoints(Guid routeId, List<Waypoint> waypoints)
        {}


        public IEnumerable<Trip> GetAllTrips()
        {
            return tripRepo.GetAll();
        }
    }
}
