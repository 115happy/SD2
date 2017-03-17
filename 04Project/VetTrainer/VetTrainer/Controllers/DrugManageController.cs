using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;
using VetTrainer.Views.ViewModel;

namespace VetTrainer.Controllers
{
    public class DrugManageController : Controller
    {
        // GET: DrugManage
        public ActionResult Index()
        {
            DrugsViewModel model = new DrugsViewModel();
            model.drugs = GetAllDrugs();
            return View(model);
        }
        private IList<Drug> GetAllDrugs()
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                List<Drug> drugs = context.Drugs.ToList();
                return drugs;
            }
        }
    }
}