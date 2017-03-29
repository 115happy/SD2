using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Controllers.Apis
{
    public class ClinicInstrumentAddController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostClinicInstrumentAdd(ClinicDto clinic)
        {
            string msg = "";
            if (clinic == null)
            {
                msg = "参数错误";
            }
            var clinicToAdd = _context.Clinics.Find(clinic.Id);
            _context.Entry(clinicToAdd).Collection(u => u.Instruments);
            foreach(Instrument i in clinicToAdd.Instruments)
            {
                _context.Entry(i).Collection(u => u.Texts);
                _context.Entry(i).Collection(u => u.Pictures);
                _context.Entry(i).Collection(u => u.Videos);
            }
            foreach(InstrumentDto ist in clinic.Instruments)
            {
                var instrumentToAdd = _context.Instruments.Find(ist.Id);
                foreach(TextDto t in ist.Texts)
                {
                    var textToAdd = Mapper.Map<TextDto, Text>(t);
                    instrumentToAdd.Texts.Add(textToAdd);
                }
                foreach (PictureDto p in ist.Pictures)
                {
                    var picToAdd = Mapper.Map<PictureDto, Picture>(p);
                    instrumentToAdd.Pictures.Add(picToAdd);
                }
                foreach(VideoDto v in ist.Videos)
                {
                    var videoToAdd = Mapper.Map<VideoDto, Video>(v);
                    instrumentToAdd.Videos.Add(videoToAdd);
                }
                clinicToAdd.Instruments.Add(instrumentToAdd);
            }
            try
            {
                _context.Entry(clinicToAdd).State = EntityState.Modified;
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
