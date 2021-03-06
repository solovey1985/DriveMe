﻿using System;
using System.Collections.Generic;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{
    public class Route:Entity
    {
        
        public string Title { get; set; }

        public Location StartPoint { get; set; }

        public Location EndPoint { get; set; }

        public List<Location> BoardingLocations { get; set; }

        public List<Location> LandingLocations { get; set; }

        public Guid? TripId { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}