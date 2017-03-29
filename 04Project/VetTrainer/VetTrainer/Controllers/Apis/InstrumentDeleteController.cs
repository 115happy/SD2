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
using System.IO;

namespace VetTrainer.Controllers.Apis
{
    public class InstrumentDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostInstrumentDelete(InstrumentDto instrument)
        {
            string msg = "";
            if (instrument == null)
            {
                msg = "参数错误";
            }
            var instrumentToDelete = _context.Instruments.Find(instrument.Id);
            _context.Entry(instrumentToDelete).Collection(u => u.Texts).Load();
            _context.Entry(instrumentToDelete).Collection(u => u.Pictures).Load();
            _context.Entry(instrumentToDelete).Collection(u => u.Videos).Load();

            var instrumentToDeleteDto = Mapper.Map<Instrument, InstrumentDto>(instrumentToDelete);
            if (instrumentToDelete == null)
            {
                msg = "删除失败，该用户不存在";
            }
            else
            {
                try
                {
                    foreach(TextDto t in instrumentToDeleteDto.Texts)
                    {
                        Text text = _context.Texts.Find(t.Id);
                        _context.Texts.Remove(text);
                    }
                    foreach(PictureDto p in instrumentToDeleteDto.Pictures)
                    {
                        Picture picture = _context.Pictures.Find(p.Id);
                        //string strpath
                        _context.Pictures.Remove(picture);
                    }
                    foreach(VideoDto v in instrumentToDeleteDto.Videos)
                    {
                        Video video = _context.Videos.Find(v.Id);
                        _context.Videos.Remove(video);
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

            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
            return Ok(str);
        }
    }
}
