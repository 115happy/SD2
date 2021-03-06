﻿using System;
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
                List<DiseaseType> diseaseTypes = _context.DiseaseType.Include(u => u.Diseases).AsNoTracking().ToList();

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
        public IHttpActionResult GetSearchResult(string searchText)
        {
            string msg = "";
            var DiseaseTypeDtos = new List<DiseaseTypeDto>();
            try
            {
                List<DiseaseType> diseaseTypes = new List<DiseaseType>();

                if (searchText == null || searchText.Trim() == "")
                {
                    diseaseTypes = _context.DiseaseType.Include(u => u.Diseases).AsNoTracking().ToList();
                }
                else
                {
                    diseaseTypes = _context.DiseaseType.Where(u => u.Name.Contains(searchText)).Include(u => u.Diseases).AsNoTracking().ToList();
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
    }
}
