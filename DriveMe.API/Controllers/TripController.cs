using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

using Driveme.Domain.Services.Factories;
using DriveMe.API.Providers;
using DriveMe.Domain.Models;
using DriveMe.GUI.AppServices;
using StackExchange.Redis;



namespace DriveMe.API.Controllers
{
    [RoutePrefix("api/trip")]
    public class TripController : ApiController
    {
        private TripService service;
        // Redis Connection string info
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["RedisConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });
        public static ConnectionMultiplexer Connection => lazyConnection.Value;

        public TripController()
        {
          

            service = new TripService(new BaseFactory<Trip>());
        }
        [Route]
        public async Task<IHttpActionResult> Get()
        {
            IDatabase cache = Connection.GetDatabase();

            string d = cache.StringGet("m");
            if (String.IsNullOrEmpty(d))
            {
                d = DateTime.Now.ToString();
                cache.StringSet("m", d);

            }
            return Ok(new {Trips = service.GetAll(), Date = d});
        }
        [Route("{Id:Guid}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            return Ok(service.GetById(id));
        }
        [Route]
        public async Task<IHttpActionResult> Post([FromBody]Trip trip)
        {
            var cache = Connection.GetDatabase();
            cache.StringSetAsync("m", DateTime.Now.ToString(), new TimeSpan(0, 0, 0, 90));
            Guid id = service.Create(trip);
            
            return Ok(id);
        }

        [HttpPut]
        [Route]
        public async Task<IHttpActionResult> Put([FromBody]Trip trip)
        {
            Guid id = service.Update(trip);
            return Ok(id);
        }

        
        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            
            service.DeleteById(id);
            return Ok();
        }

        #region Routes
        [Route("{id:Guid}/route")]
        public async Task<IHttpActionResult> GetRoute(Guid tripId)
        {
            Route route = service.GetRouteByTripId(tripId);
            return Ok(new Route());
        }

        [Route("{id:Guid}/route")]
        public async Task<IHttpActionResult> PostRoute(Route route)
        {
            service.AddRoute(route);
            return Ok(route.Id);
        }

        [Route("{id:Guid}/route")]
        public async Task<IHttpActionResult> PutRoute(Route route)
        {
            service.UpdateRoute(route);
            return Ok(route.Id);
        }

        [Route("{id:Guid}/route")]
        public async Task<IHttpActionResult> DeleteRoute(Guid id)
        {
            service.DeleteRoute(id);
            return Ok();
        }
        #endregion 
        
        #region Passengers
        #endregion
        
        #region Schedule
        #endregion
        
        #region

   

        #endregion
    }
}

