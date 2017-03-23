using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;
using System.Data.Entity;
using AutoMapper;
using System.Data.Entity.Infrastructure;
using System.Web.Script.Serialization;

namespace VetTrainer.Controllers.Apis
{
    public class DiseaseTypeSearchController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();
        // GET: RoleSearch
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetSearchResult()
        {
            string msg = "";
            var DiseaseTypeDtos = new List<DiseaseTypeDto>();
            try
            {
                List<DiseaseType> diseaseTypes = _context.DiseaseTypes.Include(u => u.Diseases.Select(v => v.DiseaseCases.Select(w => w.DiseaseCaseTabs))).ToList();
                foreach (DiseaseType dt in diseaseTypes)
                {
                    foreach (Disease d in dt.Diseases)
                    {
                        foreach(DiseaseCase dc in d.DiseaseCases)
                        {
                            foreach(DiseaseCaseTab dct in dc.DiseaseCaseTabs)
                            {
                                _context.Entry(dct).Collection(u => u.Analyses);
                                _context.Entry(dct).Collection(u => u.Drugs);
                                _context.Entry(dct).Collection(u => u.Texts);
                                _context.Entry(dct).Collection(u => u.Pictures);
                                _context.Entry(dct).Collection(u => u.Videos);
                            }
                        }
                    }
                }
                foreach (DiseaseType dt in diseaseTypes)
                {
                    var diseaseTypeDto = Mapper.Map<DiseaseType, DiseaseTypeDto>(dt);
                    DiseaseTypeDtos.Add(diseaseTypeDto);
                }
                if (DiseaseTypeDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(DiseaseTypeDtos) + " }";
            return Ok(str);
        }
        //获取查询用户信息结果api
        public IHttpActionResult GetSearchResult(string searchText)
        {
            string msg = "";
            var clinicDtos = new List<ClinicDto>();
            try
            {
                List<Clinic> clinics = _context.Clinics.Include(u => u.Instruments)
                    .Include(u => u.Texts).Include(u => u.Pictures)
                    .Include(u => u.Videos).ToList();

                if (searchText == null || searchText.Trim() == "")
                {
                    clinics = _context.Clinics.Include(u => u.Instruments)
                    .Include(u => u.Texts).Include(u => u.Pictures)
                    .Include(u => u.Videos).ToList();
                }
                else
                {
                    clinics = _context.Clinics.Where(u => u.Name.Contains(searchText)).Include(u => u.Instruments)
                    .Include(u => u.Texts).Include(u => u.Pictures)
                    .Include(u => u.Videos).ToList();
                }
                foreach (Clinic c in clinics)
                {
                    foreach (Instrument i in c.Instruments)
                    {
                        _context.Entry(i).Collection(u => u.Texts).Load();
                        _context.Entry(i).Collection(u => u.Pictures).Load();
                        _context.Entry(i).Collection(u => u.Videos).Load();
                    }
                }
                foreach (Clinic clinic in clinics)
                {
                    var clinicDto = Mapper.Map<Clinic, ClinicDto>(clinic);
                    clinicDtos.Add(clinicDto);
                }
                if (clinicDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(clinicDtos) + " }";
            return Ok(str);
        }
    }
}
