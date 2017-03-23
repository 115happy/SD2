﻿using AutoMapper;
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
    public class DiseaseTypeDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostDiseaseTypeDelete(DiseaseTypeDto diseaseType)
        {
            string msg = "";
            if (diseaseType == null)
            {
                msg = "参数错误";
            }
            var diseaseTypeToDelete = _context.DiseaseType.Find(diseaseType.Id);
            if (diseaseTypeToDelete == null)
            {
                msg = "删除失败，该用户不存在";
            }
            else
            {
                try
                {
                    DiseaseTypeDto diseaseTypeToDeleteDto = Mapper.Map<DiseaseType, DiseaseTypeDto>(diseaseTypeToDelete);
                    foreach (DiseaseDto d in diseaseTypeToDeleteDto.Diseases)
                    {
                        var disease = _context.Diseases.Find(d.Id);
                        foreach(DiseaseCaseDto dc in d.DiseaseCases)
                        {
                            var diseaseCase = _context.DiseaseCases.Find(dc.Id);
                            if(diseaseCase.Diseases.Count==1)
                            {
                                foreach(DiseaseCaseTabDto dct in dc.DiseaseCaseTabs)
                                {
                                    var diseaseCaseTab = _context.DiseaseCaseTabs.Find(dct.Id);
                                    diseaseCaseTab.Drugs.Clear();
                                    diseaseCaseTab.Analyses.Clear();
                                    foreach(TextDto t in dct.Texts)
                                    {
                                        var text = _context.Texts.Find(t.Id);
                                        _context.Texts.Remove(text);
                                    }
                                    foreach(PictureDto p in dct.Pictures)
                                    {
                                        var picture = _context.Pictures.Find(p.Id);
                                        _context.Pictures.Remove(picture);
                                    }
                                    foreach(VideoDto v in dct.Videos)
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
                        _context.Diseases.Remove(disease);
                    }
                    diseaseTypeToDelete.Diseases.Clear();
                    _context.DiseaseType.Remove(diseaseTypeToDelete);
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