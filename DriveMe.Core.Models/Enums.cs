using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveMe.Core.Models
{
    public enum Direction
    {
        /// <summary>
        /// On the left hand of the user
        /// </summary>
        Left,
        /// <summary>
        /// On the right hand of the user
        /// </summary>
        Right,
        /// <summary>
        /// In front of the user
        /// </summary>
        Front,
        /// <summary>
        /// At the back of the user
        /// </summary>
        Back
    }

    public enum LandmarkType
    {
        Shop,
        BusStop,
        TramStop,
        BussinessCenter,
        Market
    }

    public enum LocationType
    {
        Boarding,
        Landing,
        Landmark
    }

    public enum PassengerStatus
    {
        Waiting,
        Onboard,
        Free
    }

    public enum DriverStatus
    {
        Waiting,
        OnRoute,
        Free
    }
}