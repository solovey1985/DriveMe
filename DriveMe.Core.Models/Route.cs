using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{
    public class Route:EntityBase
    {

        public string Title { get; set; }

        public Location StartPoint { get; set; }

        public Location EndPoint { get; set; }

        public List<Location> BoardingLocations { get; set; }

        public List<Location> LandingLocations { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}