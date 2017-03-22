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
    public class InstrumentDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostUserDelete(InstrumentDto instrument)
        {
            string msg = "";
            if (instrument == null)
            {
                msg = "参数错误";
            }
            var instrumentToDelete = _context.Instruments.Find(instrument.Id);
            
            if (instrumentToDelete == null)
            {
                msg = "删除失败，该用户不存在";
            }
            else
            {
                try
                {
                    foreach(Text t in instrumentToDelete.Texts)
                    {
                        _context.Texts.Remove(t);
                    }
                    foreach(Picture p in instrumentToDelete.Pictures)
                    {
                        _context.Pictures.Remove(p);
                    }
                    foreach(Video v in instrumentToDelete.Videos)
                    {
                        _context.Videos.Remove(v);
                    }

                    _context.Instruments.Remove(instrumentToDelete);

                    _context.SaveChanges();
                    msg = "删除成功";
                }
                catch (RetryLimitExceededException)
                {
                    msg = "网络故障";
                }
            }

            var str = "[{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }]";
            return Ok(str);
        }
    }
}
