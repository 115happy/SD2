using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Controllers;
using VetTrainer.Models;
using VetTrainer.Views.ViewModel;
using System.Data.Entity;
using System.Runtime.Serialization.Json;
using System.IO;
using VetTrainer.Utilities;
using System.Web.Script.Serialization;

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
            IQueryable<DiseaseType> diseaseTypes = _context.DiseaseTypes.Include(dt => dt.Diseases.Select(d => d.DiseaseCases));
            //var diseaseTypes = _context.DiseaseTypes.Include(dt => dt.Diseases);
            //seldiseaseCase.Diseases = diseases;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = "[";
            foreach (DiseaseType diseaseType in diseaseTypes)
            {
                json += jss.Serialize(diseaseType)+","; 
            }
            json += "]";
            return View(json);
        }
        [Route("CaseLearning")]
        public ActionResult CaseLearning(String diseaseCaseName)
        {
            var diseaseCases = _context.DiseaseCases.Include(dc => dc.DiseaseCaseTabs).Where(dc => dc.Name == diseaseCaseName);
            return View(diseaseCases);
        }
    }
}