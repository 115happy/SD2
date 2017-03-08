using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetTrainer.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("~/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("~/Login")]
        public ActionResult Login()
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