﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.Infrastructure
{
    public class RepositoryBase<T>: IRepository<T> where T:EntityBase
    {
    }
}