using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DriveMe.Domain.Models;

namespace DriveMe.API.Controllers
{
    public class TripController : ApiController
    {
        public OkNegotiatedContentResult<Trip> Get()
        {
            throw new NotImplementedException();
        }
        public OkNegotiatedContentResult<Trip> Get(Guid id)
        {
            throw new NotImplementedException();
        }
        public OkNegotiatedContentResult<Trip> Post()
        {
            throw new NotImplementedException();
        }

        public OkNegotiatedContentResult<Trip> Put()
        {
            throw new NotImplementedException();
        }

        public OkNegotiatedContentResult<Trip> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
