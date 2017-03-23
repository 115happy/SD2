using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Controllers.Apis
{
    public class AnalysisDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostAnalysisDelete(AnalysisDto analysis)
        {
            string msg = "";
            if (analysis == null)
            {
                msg = "参数错误";
            }
            var analysisToDelete = _context.Analyses.Find(analysis.Id);
            if (analysisToDelete == null)
            {
                msg = "删除失败，该化验项目不存在";
            }
            else
            {
                try
                {
                    _context.Analyses.Remove(analysisToDelete);
                    _context.SaveChanges();
                    msg = "删除成功";
                }
                catch (RetryLimitExceededException)
                {
                    msg = "网络故障";
                }
            }

            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
            return Ok(str);
        }
    }
}
