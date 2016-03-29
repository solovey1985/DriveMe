using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.DAL.Identity.Models.Trip
{
    public class Schedule:DrivemeIdentity
    {
        public DateTime StartTime { get; set; }
        public Trip Trip { get; set; }
        public int Tripid { get; set; }

        
    }
}
