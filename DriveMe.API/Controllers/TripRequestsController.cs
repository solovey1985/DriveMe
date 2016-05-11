using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DriveMe.GUI.ViewModels.Api;
using DriveMe.GUI.ViewModels.Common;
namespace DriveMe.API.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class TripRequestsController : ApiController
    {
        public TripRequest Get(int id){
            return new TripRequest() {StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2)};
        }

        public Trip Post(TripRequest tripRequest)
        {
            return new Trip() {};
        }
        [HttpPost]
        [ActionName("Trip")]
        public Trip Trip(TripRequest tripRequest)
        {
            return new Trip() { Driver = new Driver() {Vehicle = new Vehicle() {Color = ConsoleColor.Black, Model = "dsdfdsf"} } };
        }

        
    }
}
