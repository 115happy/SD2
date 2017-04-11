﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        // POST: api/clinicinstrumentaddcontroller
        public IHttpActionResult PostClinicInstrumentAdd()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            var httpRequest = HttpContext.Current.Request;
            var clinic_Id = httpRequest.Form["clinicId"];
            var instrument_Id = httpRequest.Form["instrumentId"];
            var text = httpRequest.Form["description"];
            string msg = "";
            if (clinic_Id == null && instrument_Id == null)
            {
                msg = "请选择要添加的科室与操作器械关联";
            }

            int clinicId = int.Parse(clinic_Id);
            int instrumentId = int.Parse(instrument_Id);

            var clinicToAdd = _context.Clinics.Find(clinicId);
            _context.Entry(clinicToAdd).Collection(u => u.Instruments);
            bool flag = true;
            foreach(Instrument i in clinicToAdd.Instruments)
            {
                if (i.Id == instrumentId)
                {
                    msg = "此科室与操作器械关联已存在！";
                    flag = false;
                }
            }
            if (flag)
            {

                foreach (Instrument i in clinicToAdd.Instruments)
                {
                    _context.Entry(i).Collection(u => u.Texts);
                    _context.Entry(i).Collection(u => u.Pictures);
                    _context.Entry(i).Collection(u => u.Videos);
                }

                var instrumentToAdd = _context.Instruments.Find(instrumentId);

                TextDto t = new TextDto();
                t.Name = clinicToAdd.Name + "-" + instrumentToAdd.Name;
                t.Content = text;
                var textToAdd = Mapper.Map<TextDto, Text>(t);
                instrumentToAdd.Texts.Add(textToAdd);
                if (httpRequest.Files.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i < httpRequest.Files.Count; i++)
                        {
                            var postedFile = httpRequest.Files[i];
                            var x = postedFile.ContentType;
                            Image image = Bitmap.FromStream(postedFile.InputStream);
                            var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                            image.Save(filePath, ImageFormat.Jpeg);
                        }
                    }
                    catch
                    {

                    }
                }else
                {
                    msg = "请上传图片和视频!";
                }
                //foreach (PictureDto p in ist.Pictures)
                //{
                //    var picToAdd = Mapper.Map<PictureDto, Picture>(p);
                //    instrumentToAdd.Pictures.Add(picToAdd);

                //    //// GetPicture
                //    //var httpRequest = HttpContext.Current.Request;
                //}
                //foreach (VideoDto v in ist.Videos)
                //{
                //    var videoToAdd = Mapper.Map<VideoDto, Video>(v);
                //    instrumentToAdd.Videos.Add(videoToAdd);
                //}
                clinicToAdd.Instruments.Add(instrumentToAdd);
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
            }
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
            return Ok(str);
        }
    }
}
