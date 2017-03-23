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
    public class DrugSearchController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetSearchResult()
        {
            string msg = "";
            var drugDtos = new List<DrugDto>();
            try
            {
                List<Drug> drugs = new List<Drug>();
                drugs = _context.Drugs.ToList();
                foreach (Drug drug in drugs)
                {
                    var drugDto = Mapper.Map<Drug, DrugDto>(drug);
                    drugDtos.Add(drugDto);
                }
                if (drugDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "[{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(drugDtos) + " }]";
            return Ok(str);
        }
        //获取查询用户信息结果api
        public IHttpActionResult GetSearchResult(string searchText)
        {
            string msg = "";
            var drugDtos = new List<DrugDto>();
            try
            {
                List<Drug> drugs = new List<Drug>();
                if (searchText == null || searchText.Trim() == "")
                {
                    drugs = _context.Drugs.ToList();
                }
                else
                {
                    drugs = _context.Drugs.Where(u => u.Name.Contains(searchText)).ToList();
                }
                foreach (Drug drug in drugs)
                {
                    var drugDto = Mapper.Map<Drug, DrugDto>(drug);
                    drugDtos.Add(drugDto);
                }
                if (drugDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(drugDtos) + " }";
            return Ok(str);
        }
    }
}
