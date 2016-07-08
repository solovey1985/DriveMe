using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using DriveMe.DAL.Repositories;
using DriveMe.Domain.Models;

namespace DriveMe.GUI.Web.Controllers
{
    public class RouteController : Controller
    {
        ITripRepository _tripRepository;
        public RouteController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;

        }
        // GET: Route
        public ActionResult Index()
        {
            List<Trip> trips = _tripRepository.GetAll().ToList();
            foreach (Trip trip in trips)
            {
                Debug.WriteLine(trip.Title);
            }
            return View();
        }

        private int myVar;

        public ActionResult Test()
        {
           return View();
        }

    }

}

