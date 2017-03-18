using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Controllers;
using VetTrainer.Models;
using VetTrainer.Views.ViewModel;
using System.Data.Entity;

namespace VetTrainer.Controllers
{
    [RoutePrefix("Case")]
    public class CaseController : Controller
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route]
        public ActionResult CaseSelect()
        {
            var diseaseTypes = _context.DiseaseTypes.Include(dt => dt.Diseases.Select(d => d.DiseaseCases));
            //var diseaseTypes = _context.DiseaseTypes.Include(dt => dt.Diseases);
            //seldiseaseCase.Diseases = diseases;
            return View(diseaseTypes);
        }
        [Route("CaseLearning")]
        public ActionResult CaseLearning()
        {
            return View();
        }
    }
}