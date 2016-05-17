using System;

namespace DriveMe.Domain.Models
{
    public class Passenger : User
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}