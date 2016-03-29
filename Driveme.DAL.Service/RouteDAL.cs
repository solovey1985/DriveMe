using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.DAL.Identity.Models;

namespace DriveMe.DAL.Service
{
    public interface IRouteDalService: IDalService<Route>
    {
    }

    public class RouteDalService : DalService<Route>, IRouteDalService
    {
    }
}
