using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveMe.Core.Models
{
    public class Waypoint
    {
        public Position Position { get; set; }

        public int RouteId { get; set; }

        public DateTime Time { get; set; }
    }
}