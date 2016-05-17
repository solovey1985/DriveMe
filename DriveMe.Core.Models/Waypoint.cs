using System;

namespace DriveMe.Domain.Models
{
    public class Waypoint
    {
        public Position Position { get; set; }

        public int RouteId { get; set; }

        public DateTime Time { get; set; }
    }
}