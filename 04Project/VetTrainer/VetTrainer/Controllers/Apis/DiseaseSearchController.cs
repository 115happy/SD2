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
    public class DiseaseSearchController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetSearchResult()
        {
            string msg = "";
            var DiseaseDtos = new List<DiseaseDto>();
            try
            {
                /*.Include(v => v.DiseaseCases.Select(w => w.DiseaseCaseTabs))*/
                List<Disease> diseases = _context.Diseases.ToList();
                //foreach (Disease d in diseases)
                //{
                //    foreach (DiseaseCase dc in d.DiseaseCases)
                //    {
                //        foreach (DiseaseCaseTab dct in dc.DiseaseCaseTabs)
                //        {
                //            _context.Entry(dct).Collection(u => u.Analyses);
                //            _context.Entry(dct).Collection(u => u.Drugs);
                //            _context.Entry(dct).Collection(u => u.Texts);
                //            _context.Entry(dct).Collection(u => u.Pictures);
                //            _context.Entry(dct).Collection(u => u.Videos);
                //        }
                //    }
                //}
                foreach (Disease d in diseases)
                {
                    var diseaseDto = Mapper.Map<Disease, DiseaseDto>(d);
                    DiseaseDtos.Add(diseaseDto);
                }
                if (DiseaseDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(DiseaseDtos) + " }";
            return Ok(str);
        }
        public IHttpActionResult GetSearchResult(string searchText)
        {
            string msg = "";
            var DiseaseDtos = new List<DiseaseDto>();
            try
            {
                List<Disease> diseases= new List<Disease>();

                if (searchText == null || searchText.Trim() == "")
                {
                    diseases = _context.Diseases.Include(v => v.DiseaseCases.Select(w => w.DiseaseCaseTabs)).ToList();
                }
                else
                {
                    diseases = _context.Diseases.Where(u => u.Name.Contains(searchText)).Include(v => v.DiseaseCases.Select(w => w.DiseaseCaseTabs)).ToList();
                }
                foreach (Disease d in diseases)
                {
                    foreach (DiseaseCase dc in d.DiseaseCases)
                    {
                        foreach (DiseaseCaseTab dct in dc.DiseaseCaseTabs)
                        {
                            _context.Entry(dct).Collection(u => u.Analyses);
                            _context.Entry(dct).Collection(u => u.Drugs);
                            _context.Entry(dct).Collection(u => u.Texts);
                            _context.Entry(dct).Collection(u => u.Pictures);
                            _context.Entry(dct).Collection(u => u.Videos);
                        }
                    }
                }
                foreach (Disease d in diseases)
                {
                    var diseaseDto = Mapper.Map<Disease, DiseaseDto>(d);
                    DiseaseDtos.Add(diseaseDto);
                }
                if (DiseaseDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(DiseaseDtos) + " }";
            return Ok(str);
        }
    }
}
