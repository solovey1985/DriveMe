using System.Collections.Generic;
using DriveMe.Domain.Models;
using System.Web.Http;
using Ninject;

namespace DriveMe.API.Controllers
{
  
    public class RoutesController : ApiController
    {
        List<Route>  routes = new List<Route>();
       
        // GET api/values
        public IEnumerable<Route> Get()
        {

            return new List<Route>(23);
        }

        // GET api/values/5
        public string Get(int id)
        {
            Route r = new Route();
            return r==null?"value":r.Title;
        }

        // POST api/values
        public void Post([FromBody]Route value)
        {
            routes.Add(value);
        }

        // PUT api/values/5
        public void Put(Route route)
        {
            Route routeToUpdate = routes.Find(r => r.Id == route.Id);

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
