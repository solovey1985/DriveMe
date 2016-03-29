using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DriveMe.DAL.Service;
using DriveMe.DAL.Identity;
using DriveMe.DAL.Identity.Models;
using Ninject;

namespace DriveMe.API.Controllers
{
  
    public class RoutesController : ApiController
    {
        [Inject]
        public IRouteDalService service { get; set; }
        // GET api/values
        public IEnumerable<Route> Get()
        {

            return service.Get();
        }

        // GET api/values/5
        public string Get(int id)
        {
            Route r = service.Get(v => v.Id == id).FirstOrDefault();
            return r==null?"value":r.Title;
        }

        // POST api/values
        public void Post([FromBody]Route value)
        {
            service.Add(value);
        }

        // PUT api/values/5
        public void Put(Route route)
        {
            service.Update(route);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
