using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        public ActionResult UploadInstrumentPic(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/pics/instruments"), fileName);
                file.SaveAs(path);

            }

            return RedirectToAction("Index");
        }
    }
}