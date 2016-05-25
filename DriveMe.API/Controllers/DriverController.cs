using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using DriveMe.Domain.Models;
using DriveMe.GUI.AppServices;

namespace DriveMe.API.Controllers
{
    public class DriverController : ApiController
    {
        private DriverService service;

        public DriverController()
        {
            service = new DriverService();

        }
        [Authorize]
        public OkNegotiatedContentResult<IEnumerable<Driver>> Get()
        {
            return Ok(service.GetAllDrivers());
        }

        public OkNegotiatedContentResult<Driver> Get(Guid id)
        {
            return Ok(service.GetDriverById(id));
        }

        public OkNegotiatedContentResult<Guid> Post(Driver driver)
        {
            return Ok(service.CreateDriver(driver));
        }
       
        public OkNegotiatedContentResult<Guid> Put([FromBody]Driver driver)
        {
            Console.WriteLine(User.Identity.IsAuthenticated);
            return Ok(service.Update(driver));
        }


    }
}
