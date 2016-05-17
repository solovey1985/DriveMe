using System;
using System.Collections.Generic;
using System.Reflection;

namespace DriveMe.Domain.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Route = new Route();
            Passangers =new List<Passenger>();
            
        }

        protected Trip(Guid id):base(id)
        {
            
        }
        public Trip(Guid userId, Location startPoint, Location endPoint, DateTime startTime, DateTime endTime):this()
        {
            Driver = new Driver(userId) {};
            Route.StartPoint    = startPoint;
            Route.EndPoint      = endPoint;
            StartTime           = startTime;
            EndTime             = endTime;

        }

        #region CRUD

        public Trip GetById(int Id)
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }

        public Trip Create()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }

        public bool Delete()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }

        public Trip Update()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }

        #endregion

        #region Route

        public bool SetLandingPoint()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }

        public bool SetBoardingPoint()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }
        
        public bool SetStartTime()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }

        public bool SetEndTime()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }

        public bool AddWaypooint()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }

        public bool RemoveWaypoint()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }

        #endregion

        #region Passengers
        public bool AddPassenger()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }
        public bool RemovePassenger()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }
        public bool NotifyPassenger()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }
        public bool SubmitPassenger()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }
        public bool DiscardPassneger()
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }
        #endregion

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
