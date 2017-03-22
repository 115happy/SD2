using AutoMapper;
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
    public class AnalysisAddController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostAnalysisAdd(AnalysisDto analysis)
        {
            string msg = "";
            if (analysis == null)
            {
                msg = "参数错误";
            }
            var AnalysisToAdd = Mapper.Map<AnalysisDto, Analysis>(analysis);
            try
            {
                _context.Analyses.Add(AnalysisToAdd);
                _context.SaveChanges();
                msg = "添加成功";
            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            var str = "[{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }]";
            return Ok(str);
        }
    }
}
