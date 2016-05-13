﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.Domain.Models;
using DriveMe.Infrastructure;

namespace DriveMe.DAL.Repositories
{
    public interface ITripRepository:IRepository<Trip> { }

    public class TripRepository:RepositoryBase<Trip>, ITripRepository
    {
        
       
    }
}
