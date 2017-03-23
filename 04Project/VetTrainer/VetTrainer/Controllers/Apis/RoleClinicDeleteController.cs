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
    public class RoleClinicDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostRoleClinicDelete(RPRecordDto rpRecord)
        {
            string msg = "";
            var roleToDelete = _context.Roles.Find(rpRecord.RoleId);
            var clinicToDelete = _context.Clinics.Find(rpRecord.ClinicId);
            if (rpRecord == null || roleToDelete == null || clinicToDelete == null)
            {
                msg = "参数错误";
            }
            var rpRecordToDelete = _context.RPRecords.Find(rpRecord.RoleId, rpRecord.ClinicId);
            var rpRecordToDeleteDto = Mapper.Map<RPRecord, RPRecordDto>(rpRecordToDelete);

            try
            {
                foreach (PictureDto p in rpRecordToDeleteDto.Pictures)
                {
                    var picture = _context.Pictures.Find(p.Id);
                    _context.Pictures.Remove(picture);
                }
                foreach (VideoDto v in rpRecordToDeleteDto.Videos)
                {
                    var video = _context.Videos.Find(v.Id);
                    _context.Videos.Remove(video);
                }
                _context.RPRecords.Remove(rpRecordToDelete);
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
