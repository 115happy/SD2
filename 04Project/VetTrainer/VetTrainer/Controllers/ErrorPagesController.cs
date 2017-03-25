using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetTrainer.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Redirect")]
    public class ErrorPagesController : Controller
    {
        // GET: RequestErr
        [Route("404")]
        public ActionResult Error404()
        {
            return View();
        }

        [Route("AdminRequired")]
        public ActionResult ErrorAdminRequired()
        {
            return View();
        }
    }
}