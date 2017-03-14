using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetTrainer.Controllers
{
    [RoutePrefix("Case")]
    public class CaseController : Controller
    {
        [Route]
        public ActionResult CaseSelect()
        {
            return View();
        }
        [Route("CaseLearning")]
        public ActionResult CaseLearning()
        {
            return View();
        }
    }
}