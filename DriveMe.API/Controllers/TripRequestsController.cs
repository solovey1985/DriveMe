using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DriveMe.Core.Models;

namespace DriveMe.API.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class TripRequestsController : ApiController
    {
        public TripRequest Get(int id){
            return new TripRequest();
        }

        public TripRequest Post([FromBody] TripRequest tripRequest)
        {
            return new TripRequest();
        }
    }
}
