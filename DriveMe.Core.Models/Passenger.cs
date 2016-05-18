using System;

namespace DriveMe.Domain.Models
{
    public class Passenger : User
    {
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}