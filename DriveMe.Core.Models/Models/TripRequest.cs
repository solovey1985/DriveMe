using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DriveMe.Core.Models
{
    public class TripRequest
    {
        public int Id { get; set; }
        public Location StartPoint { get; set; }
        public Location EndPoint { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

    }
}