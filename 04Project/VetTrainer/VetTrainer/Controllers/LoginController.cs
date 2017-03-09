using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetTrainer.Controllers
{
    [RoutePrefix("Login")]
    public class LoginController : Controller
    {
        [Route("~/")]
        public ActionResult Login()
        {
            return View();
        }

    }
}