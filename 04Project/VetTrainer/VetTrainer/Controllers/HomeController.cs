using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Utilities;

namespace VetTrainer.Controllers
{
    [Authorize]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("~/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "115.";

            return View();
        }
    }
}