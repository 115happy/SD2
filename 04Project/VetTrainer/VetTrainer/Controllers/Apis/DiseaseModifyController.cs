using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Controllers.Apis
{
    public class DiseaseModifyController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostDiseaseTypeModify(DiseaseDto disease)
        {
            string msg = "";
            if (disease == null)
            {
                msg = "参数错误";
            }
            var diseaseToUpdate = _context.Diseases.Find(disease.Id);
            diseaseToUpdate.Name = disease.Name;
            diseaseToUpdate.DiseaseTypeId = disease.DiseaseTypeId;

            try
            {
                _context.Entry(diseaseToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
                msg = "修改成功";
            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
            return Ok(str);
        }
    }
}
