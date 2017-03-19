using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;
using System.Data.Entity;

namespace VetTrainer.Controllers
{
    public class CaseManageController : Controller
    {
        // GET: CaseManage
        public ActionResult Index(String diseaseCaseName)
        {
            return View();
        }
    }
}