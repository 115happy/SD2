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
    public class RoleClinicModifyController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostRoleClinicModify(RPRecordDto rpRecord)
        {
            string msg = "";
            var roleToAdd = _context.Roles.Find(rpRecord.RoleId);
            var clinicToAdd = _context.Clinics.Find(rpRecord.ClinicId);
            if (rpRecord == null || roleToAdd == null || clinicToAdd == null)
            {
                msg = "参数错误";
            }
            var rpRecordToModify = _context.RPRecords.Find(rpRecord.RoleId, rpRecord.ClinicId);
            _context.Entry(rpRecordToModify).Collection(u => u.Pictures).Load();
            _context.Entry(rpRecordToModify).Collection(u => u.Videos).Load();

            rpRecordToModify.Description = rpRecord.Description;
            var rpRecordToModifyDto = Mapper.Map<RPRecord, RPRecordDto>(rpRecordToModify);
            try
            {
                foreach(PictureDto p in rpRecordToModifyDto.Pictures)
                {
                    var picture = _context.Pictures.Find(p.Id);
                    _context.Pictures.Remove(picture);
                }
                foreach(VideoDto v in rpRecordToModifyDto.Videos)
                {
                    var video = _context.Videos.Find(v.Id);
                    _context.Videos.Remove(video);
                }
                rpRecordToModify.Pictures.Clear();
                foreach(PictureDto p in rpRecord.Pictures)
                {
                    var picture = Mapper.Map<PictureDto, Picture>(p);
                    rpRecordToModify.Pictures.Add(picture);
                }
                rpRecordToModify.Videos.Clear();
                foreach(VideoDto v in rpRecord.Videos)
                {
                    var video = Mapper.Map<VideoDto, Video>(v);
                    rpRecordToModify.Videos.Add(video);
                }
                _context.Entry(rpRecordToModify).State = EntityState.Modified;
                _context.SaveChanges();
                msg = "修改成功";
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
