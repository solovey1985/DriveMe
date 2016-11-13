﻿using System;
using System.Data.Entity;

namespace Bigly.Infrastructure
{
    public interface IUnitOfWork<TContext>:IDisposable where TContext:DbContext
    {
        int Save();
        TContext Context { get; }

    }
}
