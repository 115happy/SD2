using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;
using System.Data.Entity;

namespace VetTrainer.Controllers.Apis
{
    public class DiseaseCaseSearchController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetSearchResult()
        {
            string msg = "";
            var DiseaseCaseDtos = new List<DiseaseCaseDto>();
            try
            {
                List<DiseaseCase> diseaseCases = _context.DiseaseCases.Include(u => u.DiseaseCaseTabs).ToList();
                foreach(DiseaseCase dc in diseaseCases)
                {
                    foreach(DiseaseCaseTab dct in dc.DiseaseCaseTabs)
                    {
                        _context.Entry(dct).Collection(u => u.Analyses).Load();
                        _context.Entry(dct).Collection(u => u.Drugs).Load();
                        _context.Entry(dct).Collection(u => u.Texts).Load();
                        _context.Entry(dct).Collection(u => u.Pictures).Load();
                        _context.Entry(dct).Collection(u => u.Videos).Load();
                    }
                }
                foreach (DiseaseCase d in diseaseCases)
                {
                    var diseaseDto = Mapper.Map<DiseaseCase, DiseaseCaseDto>(d);
                    DiseaseCaseDtos.Add(diseaseDto);
                }
                if (DiseaseCaseDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(DiseaseCaseDtos) + " }";
            return Ok(str);
        }
        public IHttpActionResult GetSearchResult(string searchText)
        {
            string msg = "";
            var DiseaseCaseDtos = new List<DiseaseCaseDto>();
            try
            {
                List<DiseaseCase> diseaseCases = new List<DiseaseCase>();

                if (searchText == null || searchText.Trim() == "")
                {
                    diseaseCases = _context.DiseaseCases.Include(u => u.DiseaseCaseTabs).ToList();
                }
                else
                {
                    diseaseCases = _context.DiseaseCases.Where(u => u.Name.Contains(searchText)).Include(u => u.DiseaseCaseTabs).ToList();
                }
                foreach (DiseaseCase dc in diseaseCases)
                {
                    foreach (DiseaseCaseTab dct in dc.DiseaseCaseTabs)
                    {
                        _context.Entry(dct).Collection(u => u.Analyses).Load();
                        _context.Entry(dct).Collection(u => u.Drugs).Load();
                        _context.Entry(dct).Collection(u => u.Texts).Load();
                        _context.Entry(dct).Collection(u => u.Pictures).Load();
                        _context.Entry(dct).Collection(u => u.Videos).Load();
                    }
                }
                foreach (DiseaseCase d in diseaseCases)
                {
                    var diseaseDto = Mapper.Map<DiseaseCase, DiseaseCaseDto>(d);
                    DiseaseCaseDtos.Add(diseaseDto);
                }
                if (DiseaseCaseDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(DiseaseCaseDtos) + " }";
            return Ok(str);
        }
    }
}
