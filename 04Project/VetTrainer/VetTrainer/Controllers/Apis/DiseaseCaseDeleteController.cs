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
    public class DiseaseCaseDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostDiseaseCaseDelete(DiseaseCaseDto diseaseCase)
        {
            string msg = "";
            if (diseaseCase == null)
            {
                msg = "参数错误";
            }
            var diseaseCaseToDelete = _context.DiseaseCases.Find(diseaseCase.Id);
            if (diseaseCaseToDelete == null)
            {
                msg = "删除失败，该病例不存在";
            }
            else
            {
                try
                {
                    var diseaseCaseToDeleteDto = Mapper.Map<DiseaseCase, DiseaseCaseDto>(diseaseCaseToDelete);

                    foreach (DiseaseCaseTabDto dct in diseaseCaseToDeleteDto.DiseaseCaseTabs)
                    {
                        var diseaseCaseTab = _context.DiseaseCaseTabs.Find(dct.Id);
                        diseaseCaseTab.Drugs.Clear();
                        diseaseCaseTab.Analyses.Clear();
                        foreach (TextDto t in dct.Texts)
                        {
                            var text = _context.Texts.Find(t.Id);
                            _context.Texts.Remove(text);
                        }
                        foreach (PictureDto p in dct.Pictures)
                        {
                            var picture = _context.Pictures.Find(p.Id);
                            _context.Pictures.Remove(picture);
                        }
                        foreach (VideoDto v in dct.Videos)
                        {
                            var video = _context.Videos.Find(v.Id);
                            _context.Videos.Remove(video);
                        }
                        diseaseCaseTab.Texts.Clear();
                        diseaseCaseTab.Pictures.Clear();
                        diseaseCaseTab.Videos.Clear();
                        _context.DiseaseCaseTabs.Remove(diseaseCaseTab);
                    }
                    diseaseCaseToDelete.DiseaseCaseTabs.Clear();
                    _context.DiseaseCases.Remove(diseaseCaseToDelete);
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
