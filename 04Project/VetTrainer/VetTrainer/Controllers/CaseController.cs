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
            var diseaseTypes = _context.DiseaseTypes.Include(dt => dt.Diseases.Select(d => d.DiseaseCases)).ToList();
            //var diseaseTypes = _context.DiseaseTypes.Include(dt => dt.Diseases);
            //seldiseaseCase.Diseases = diseases;

            //将对象序列化json  
            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IEnumerable<DiseaseType>));
            ////创建存储区为内存流  
            //System.IO.MemoryStream ms = new MemoryStream();
            ////将json字符串写入内存流中  
            //serializer.WriteObject(ms, diseaseTypes);
            //System.IO.StreamReader reader = new StreamReader(ms);
            //ms.Position = 0;
            //string strRes = reader.ReadToEnd();
            //reader.Close();
            //ms.Close();
            return View(diseaseTypes);
        }
        [Route("CaseLearning")]
        public ActionResult CaseLearning(String diseaseCaseName)
        {
            IQueryable<DiseaseCase> diseaseCases = _context.DiseaseCases.Include(dc => dc.DiseaseCaseTabs).Where(dc => dc.Name == diseaseCaseName);
            return View(diseaseCases);
        }
    }
}