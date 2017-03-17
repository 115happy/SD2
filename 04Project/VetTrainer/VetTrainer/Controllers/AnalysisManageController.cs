using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;
using VetTrainer.Views.ViewModel;


namespace VetTrainer.Controllers
{
    public class AnalysisManageController : Controller
    {
        // GET: AnalysisManage
        public ActionResult Index()
        {
            AnalysesViewModel model = new AnalysesViewModel();
            model.Analyses = GetAllAnalyses();
            return View(model);
        }
        private IList<Analysis> GetAllAnalyses()
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                List<Analysis> analyses = context.Analyses.ToList();
                return analyses;
            }
        }
    }
}