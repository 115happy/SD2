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
    public class DiseaseDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostDiseaseDelete(DiseaseDto disease)
        {
            string msg = "";
            if (disease == null)
            {
                msg = "参数错误";
            }
            var diseaseToDelete = _context.Diseases.Find(disease.Id);
            _context.Entry(diseaseToDelete).Collection(u => u.DiseaseCases).Load();
            foreach(DiseaseCase dc in diseaseToDelete.DiseaseCases)
            {
                _context.Entry(dc).Collection(u => u.DiseaseCaseTabs).Load();
                foreach(DiseaseCaseTab dct in dc.DiseaseCaseTabs)
                {
                    _context.Entry(dct).Collection(u => u.Analyses);
                    _context.Entry(dct).Collection(u => u.Drugs);
                    _context.Entry(dct).Collection(u => u.Texts);
                    _context.Entry(dct).Collection(u => u.Pictures);
                    _context.Entry(dct).Collection(u => u.Videos);
                }
            }
            if (diseaseToDelete == null)
            {
                msg = "删除失败，该用户不存在";
            }
            else
            {
                try
                {
                    DiseaseDto diseaseToDeleteDto = Mapper.Map<Disease, DiseaseDto>(diseaseToDelete);
                    foreach (DiseaseCaseDto dc in diseaseToDeleteDto.DiseaseCases)
                    {
                        var diseaseCase = _context.DiseaseCases.Find(dc.Id);
                        _context.Entry(diseaseCase).Collection(u => u.Diseases).Load();
                        _context.Entry(diseaseCase).Collection(u => u.DiseaseCaseTabs).Load();
                        if (diseaseCase.Diseases.Count == 1)
                        {
                            foreach (DiseaseCaseTabDto dct in dc.DiseaseCaseTabs)
                            {
                                var diseaseCaseTab = _context.DiseaseCaseTabs.Find(dct.Id);
                                _context.Entry(diseaseCaseTab).Collection(u => u.Analyses).Load();
                                _context.Entry(diseaseCaseTab).Collection(u => u.Drugs).Load();
                                _context.Entry(diseaseCaseTab).Collection(u => u.Texts).Load();
                                _context.Entry(diseaseCaseTab).Collection(u => u.Pictures).Load();
                                _context.Entry(diseaseCaseTab).Collection(u => u.Videos).Load();

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
                            diseaseCase.DiseaseCaseTabs.Clear();
                            _context.DiseaseCases.Remove(diseaseCase);
                        }
                        disease.DiseaseCases.Clear();
                    }
                    _context.Diseases.Remove(diseaseToDelete);
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
