using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Authentication;
using VetTrainer.Views;
namespace VetTrainer.Controllers
{
    [AdminExclusive]
    public class SystemManagerController : Controller
    {
        // GET: SystemManager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Manage()
        {
            int count = int.Parse(Request.QueryString["ManageId"]);
            return RedirectToAction("Index", Strings.SystemManager.Manage[count]);
        }
    }
}