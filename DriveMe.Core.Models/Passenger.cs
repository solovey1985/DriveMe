using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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