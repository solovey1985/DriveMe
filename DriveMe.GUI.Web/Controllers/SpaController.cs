using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DriveMe.GUI.Web.Controllers
{
    public class SpaController : Controller
    {
        // GET: Spa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Title = "Register";
            return View();
        }
    }
}