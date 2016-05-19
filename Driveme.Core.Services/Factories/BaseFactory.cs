﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.Infrastructure;

namespace Driveme.Domain.Services.Factories
{
    public class BaseFactory<T> where T:EntityBase, new()
    {
       protected T entity;
        public virtual T Create()
        {
            entity = new T();
            entity.Id = Guid.NewGuid();
            entity.State = State.Added;
            return entity;
        }
    }
}
