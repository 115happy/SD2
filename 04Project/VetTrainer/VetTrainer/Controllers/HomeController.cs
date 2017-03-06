using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetTrainer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "制作组：115happy.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "115.";

            return View();
        }
    }
}