using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Trip = DriveMe.GUI.ViewModels.Common.Trip;
using TripRequest = DriveMe.GUI.ViewModels.Api.TripRequest;

namespace DriveMe.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TripRequestsController : ApiController
    {
    
        public TripRequest Get(int id){
            return new TripRequest() {StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2)};
        }

        public NegotiatedContentResult<TripRequest> Post(TripRequest request)
        {
            NegotiatedContentResult <TripRequest> response = new NegotiatedContentResult<TripRequest>(HttpStatusCode.OK, request, this);
            return response;
        }

        public Trip Options(int id)
        {
            return new Trip();
        }

        
    }
}
