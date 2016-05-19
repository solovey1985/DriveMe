﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.Domain.Models;

namespace Driveme.Domain.Services.Factories
{
    public class TripFactory:BaseFactory<Trip>
    {
       public Trip CreateWithRoute(Route route)
        {
            Create();
            entity.Route = route;
            return entity;
        }
    }
}
