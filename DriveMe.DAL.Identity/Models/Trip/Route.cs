using System.Collections.Generic;
using System.Linq;
using DriveMe.DAL.Identity.Models.Trip;

namespace DriveMe.DAL.Identity.Models
{
    public class Route : DrivemeIdentity
    {
        LinkedList<Waypoint> Waypoints { get; set;}

        public Waypoint GetStartPoint()
        {
            if (Waypoints == null)
                return null;
            if (!Waypoints.Any())
                return null;
            return Waypoints.First();
        }

        public Waypoint GetEndPoint()
        {
            if (Waypoints == null)
                return null;
            if (!Waypoints.Any())
                return null;
            return Waypoints.Last();
        }
    }
}
