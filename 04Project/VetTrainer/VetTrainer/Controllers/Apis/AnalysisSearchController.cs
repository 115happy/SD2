using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Controllers.Apis
{
    public class AnalysisSearchController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();
        // GET: RoleSearch
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetSearchResult()
        {
            string msg = "";
            var AnalysisDtos = new List<AnalysisDto>();
            try
            {
                List<Analysis> analyses = new List<Analysis>();
                analyses = _context.Analyses.ToList();
                foreach (Analysis analysis in analyses)
                {
                    var analysisDto = Mapper.Map<Analysis, AnalysisDto>(analysis);
                    AnalysisDtos.Add(analysisDto);
                }
                if (AnalysisDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(AnalysisDtos) + " }";
            return Ok(str);
        }
        //获取查询用户信息结果api
        public IHttpActionResult GetSearchResult(string searchText)
        {
            string msg = "";
            var AnalysisDtos = new List<AnalysisDto>();
            try
            {
                List<Analysis> analyses = new List<Analysis>();
                if (searchText == null || searchText.Trim() == "")
                {
                    analyses = _context.Analyses.ToList();
                }
                else
                {
                    analyses = _context.Analyses.Where(u => u.Name.Contains(searchText)).ToList();
                }
                foreach (Analysis analysis in analyses)
                {
                    var analysisDto = Mapper.Map<Analysis, AnalysisDto>(analysis);
                    AnalysisDtos.Add(analysisDto);
                }
                if (AnalysisDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(AnalysisDtos) + " }";
            return Ok(str);
        }
    }
}
