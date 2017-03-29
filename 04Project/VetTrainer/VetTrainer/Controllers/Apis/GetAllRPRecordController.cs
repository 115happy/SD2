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
using System.Data.Entity;

namespace VetTrainer.Controllers.Apis
{
    public class GetAllRPRecordController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();
        // GET: RoleSearch
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetAllResult()
        {
            string msg = "";
            var rpRecordDtos = new List<RPRecordDto>();
            try
            {
                List<RPRecord> rpRecord = new List<RPRecord>();
                rpRecord = _context.RPRecords.Include(u => u.Role).Include(u => u.Clinic).Include(u => u.Pictures).Include(u => u.Videos).ToList();
                foreach (RPRecord rp in rpRecord)
                {
                    var rpDto = Mapper.Map<RPRecord, RPRecordDto>(rp);
                    rpRecordDtos.Add(rpDto);
                }
                if (rpRecordDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(rpRecordDtos) + " }";
            return Ok(str);
        }
    }
}
