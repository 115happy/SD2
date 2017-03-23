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
    public class InstrumentAddController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostInstrumentAdd(InstrumentDto instrument)
        {
            string msg = "";
            if (instrument == null)
            {
                msg = "参数错误";
            }
            var instrumentToAdd = Mapper.Map<InstrumentDto, Instrument>(instrument);
            try
            {
                _context.Instruments.Add(instrumentToAdd);
                _context.SaveChanges();
                msg = "添加成功";
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
