using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;
using AutoMapper;

namespace VetTrainer.Controllers.Apis
{
    public class CaseController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/case
        public IHttpActionResult GetDiseaseTypes()
        {
            var diseaseTypes = _context.DiseaseType.Include(dt => dt.Diseases.Select(d => d.DiseaseCases)).ToList();
            //var diseaseTypes = _context.DiseaseTypes.ToList();
            //if (diseaseTypes == null) return NotFound();

            var diseaseTypeDtos = new List<DiseaseTypeDto>();
            foreach (DiseaseType dt in diseaseTypes)
            {
                var dtDto = Mapper.Map<DiseaseType, DiseaseTypeDto>(dt);
                diseaseTypeDtos.Add(dtDto);
            }

            return Ok(diseaseTypeDtos);
        }
    }
}
