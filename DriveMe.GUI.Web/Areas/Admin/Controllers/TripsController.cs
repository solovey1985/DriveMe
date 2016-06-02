using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DriveMe.GUI.Web.Areas.Admin.Controllers
{
    public class TripsController : Controller
    {
        // GET: Admin/Trips
        public ActionResult Index()
        {
            return View();
        }
    }
}