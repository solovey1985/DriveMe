using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveMe.Core.Models
{
    public class Route
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Location StartPoint { get; set; }

        public Location EndPoint { get; set; }

        public List<Location> BoardingLocations { get; set; }

        public List<Location> LandingLocations { get; set; }
    }
}