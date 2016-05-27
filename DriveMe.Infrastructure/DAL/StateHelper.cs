using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.Infrastructure.DAL
{
    public class StateHelper
    {
        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                    case State.Added:       return EntityState.Added;
                    case State.Modified:    return EntityState.Modified;
                    case State.Deleted:     return EntityState.Deleted;
                    case State.Unchanged:   return EntityState.Unchanged;
                    default:                return EntityState.Unchanged;
            }
        }
    }
}
