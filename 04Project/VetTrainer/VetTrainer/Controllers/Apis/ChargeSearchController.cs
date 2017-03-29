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
using System.Web;

namespace VetTrainer.Controllers.Apis
{
    public class ChargeSearchController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetSearchResult()
        {
            string msg = "";
            var chargeDtos = new List<ChargeDto>();
            
            try
            {
                List<Charge> charges = new List<Charge>();
                charges = _context.Charges.ToList();
                foreach (Charge charge in charges)
                {
                    var chargeDto = Mapper.Map<Charge, ChargeDto>(charge);
                    chargeDtos.Add(chargeDto);
                }
                if (chargeDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(chargeDtos) + " }";
            return Ok(str);
        }
        //获取查询用户信息结果api
        public IHttpActionResult GetSearchResult(string searchText)
        {
            string msg = "";
            var chargeDtos = new List<ChargeDto>();
            try
            {
                List<Charge> charges = new List<Charge>();
                if (searchText == null || searchText.Trim() == "")
                {
                    charges = _context.Charges.ToList();
                }
                else
                {
                    charges = _context.Charges.Where(u => u.Name.Contains(searchText)).ToList();
                }
                foreach (Charge charge in charges)
                {
                    var chargeDto = Mapper.Map<Charge, ChargeDto>(charge);
                    chargeDtos.Add(chargeDto);
                }
                if (chargeDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(chargeDtos) + " }";
            return Ok(str);
        }
    }
}
