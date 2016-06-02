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
        private IDriverService service;

        public DriverController(IDriverService driverService)
        {
            service = driverService;

        }
        [Authorize(Roles = "Admin")]
        public OkNegotiatedContentResult<IEnumerable<User>> Get()
        {
            return Ok(service.GetAllDrivers());
        }

        public OkNegotiatedContentResult<User> Get(Guid id)
        {
            return Ok(service.GetDriverById(id));
        }

        public OkNegotiatedContentResult<Guid> Post(User driver)
        {
            return Ok(service.CreateDriver(driver));
        }
       
        public OkNegotiatedContentResult<Guid> Put([FromBody]User driver)
        {
            Console.WriteLine(User.Identity.IsAuthenticated);
            return Ok(service.Update(driver));
        }


    }
}
