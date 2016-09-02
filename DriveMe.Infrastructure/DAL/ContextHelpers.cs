using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.Infrastructure.DAL
{
    public static class ContextHelpers
    {
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<Entity>())
            {
                Entity entity = entry.Entity;
                entry.State = StateHelper.ConvertState(entity.State);
            }
        }
    }
}
