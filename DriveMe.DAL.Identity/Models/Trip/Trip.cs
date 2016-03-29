using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.DAL.Identity.Models.Trip
{
    public class Trip
    {
        public bool IsRoundTrip { get; set; }
        public IEnumerable<User> Passengers { get; set; } 
        public Vehicle Vehicle { get; set; }
        public User Driver { get; set; }
        public Route Route { get; set; }
        public int RouteId { get; set; }
        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }
    }
}
