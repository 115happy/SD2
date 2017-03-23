using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetTrainer.Controllers
{
    public class TriDInfoController : Controller
    {
        // GET: TriDInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Specification()
        {
            return View();
        }
        public ActionResult Operation()
        {
            return View();
        }
        public ActionResult Animation()
        {
            return View();
        }
    }
}