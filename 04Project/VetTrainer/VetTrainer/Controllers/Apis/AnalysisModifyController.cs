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
    public class AnalysisModifyController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostAnalysisModify(AnalysisDto analysis)
        {
            string msg = "";
            if (analysis == null)
            {
                msg = "参数错误";
            }
            var analysisToUpdate = _context.Analyses.Find(analysis.Id);

            analysisToUpdate.Name = analysis.Name;
            analysisToUpdate.Amount = analysis.Amount;
            try
            {
                _context.Entry(analysisToUpdate).State = EntityState.Modified;
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
