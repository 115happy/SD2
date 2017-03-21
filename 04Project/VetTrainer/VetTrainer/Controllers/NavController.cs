using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetTrainer.Controllers
{
    [RoutePrefix("nav")]

    public class NavController : Controller
    {
        // GET: Navigation
        [Route("chooseclinic")]
        public ActionResult ChooseClinic()
        {
            return View();
        }
        // GET: Navigation
        [Route("clinic")]
        public ActionResult Clinic()
        {
            return View();
        }

        // GET: Navigation
        [Route("tour")]
        public ActionResult Tour()
        {
            return View();
        }
    }
}