using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using DriveMe.Domain.Models;

namespace DriveMe.API.Controllers
{
    [RoutePrefix("api/trip")]
    public class TripController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            throw new NotImplementedException();
        }
        public async Task<IHttpActionResult> Get(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<IHttpActionResult> Post()
        {
            throw new NotImplementedException();
        }

        public async Task<IHttpActionResult> Put()
        {
            throw new NotImplementedException();
        }

        public async Task<IHttpActionResult> Delete()
        {
            throw new NotImplementedException();
        }

        #region Routes
        [Route("{id:Guid}/route")]
        public async Task<IHttpActionResult> GetRoute(Guid id)
        {
            return Ok(new Route());
        }

        [Route("{id:Guid}/route")]
        public async Task<IHttpActionResult> PostRoute(Guid id)
        {
            return Ok(new Route());
        }

        [Route("{id:Guid}/route")]
        public async Task<IHttpActionResult> PutRoute(Guid id)
        {   
            return Ok(new Route());
        }

        [Route("{id:Guid}/route")]
        public async Task<IHttpActionResult> DeleteRoute(Guid id)
        {
            return Ok(new Route());
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

