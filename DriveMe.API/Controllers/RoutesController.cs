using System;
using System.Collections.Generic;
using DriveMe.Domain.Models;
using System.Web.Http;
using System.Web.Http.Results;
using DriveMe.GUI.AppServices;
using Ninject;

namespace DriveMe.API.Controllers
{
  
    public class RoutesController : ApiController
    {
        List<Route>  routes = new List<Route>();
        private IDriverService service;
        public RoutesController(IDriverService service)
        {
            this.service = service;
        }

        // GET api/values
        public IEnumerable<Route> Get()
        {
            return new List<Route>(23);
        }

        // GET api/values/5
        public string Get(Guid id)
        {
            Route r = new Route();
            return r==null?"value":r.Title;
        }

        [HttpPost]
        public OkNegotiatedContentResult<Guid> Post([FromBody]Route route)
        {
           Guid routeId = service.AddRoute(route, route.Id);
            return Ok(routeId);

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
