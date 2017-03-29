using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Controllers.Apis
{
    public class ClinicInstrumentDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult DeleteClinicInstrumentDelete(int clinicId, int instrumrntId)
        {
            string msg = "";
            var clinicToDelete = _context.Clinics.Find(clinicId);
            if (clinicToDelete == null)
            {
                msg = "参数错误";
            }
            try
            {
                var clinicToDeleteDto = Mapper.Map<Clinic, ClinicDto>(clinicToDelete);
                foreach (InstrumentDto ist in clinicToDeleteDto.Instruments)
                {
                    if (ist.Id == instrumrntId)
                    {
                        var instrument = _context.Instruments.Find(ist.Id);
                        clinicToDelete.Instruments.Remove(instrument);
                        break;
                    }
                }
                _context.Entry(clinicToDelete).State = EntityState.Modified;
                _context.SaveChanges();
                msg = "删除成功";
            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
            return Ok(str);
        }
        public IHttpActionResult PostClinicInstrumentDelete(ClinicDto clinic)
        {
            string msg = "";
            if (clinic == null)
            {
                msg = "参数错误";
            }
            
            try
            {
                var clinicToDelete = _context.Clinics.Find(clinic.Id);
                foreach (InstrumentDto ist in clinic.Instruments)
                {
                    var instrumentToDelete = _context.Instruments.Find(ist.Id);
                    var instrumentToDeleteDto = Mapper.Map<Instrument, InstrumentDto>(instrumentToDelete);
                    foreach (TextDto t in instrumentToDeleteDto.Texts)
                    {
                        var text = _context.Texts.Find(t.Id);
                        _context.Texts.Remove(text);
                    }
                    foreach (PictureDto p in instrumentToDeleteDto.Pictures)
                    {
                        var picture = _context.Pictures.Find(p.Id);
                        _context.Pictures.Remove(picture);
                    }
                    foreach (VideoDto v in instrumentToDeleteDto.Videos)
                    {
                        var video = _context.Videos.Find(v.Id);
                        _context.Videos.Remove(video);
                    }
                    clinicToDelete.Instruments.Remove(instrumentToDelete);
                }
                _context.Entry(clinicToDelete).State = EntityState.Modified;
                _context.SaveChanges();
                msg = "删除成功";
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
