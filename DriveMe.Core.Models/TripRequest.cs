using System;


namespace DriveMe.Domain.Models
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