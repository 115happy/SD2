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
    public class DiseaseCaseModifyController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostDiseaseCaseModify(DiseaseCaseDto diseaseCase)
        {
            string msg = "";
            if (diseaseCase == null)
            {
                msg = "参数错误";
            }
            var diseaseCaseToUpdate = _context.DiseaseCases.Find(diseaseCase.Id);
            _context.Entry(diseaseCaseToUpdate).Collection(u => u.DiseaseCaseTabs).Load();
            
            foreach(DiseaseCaseTab dct in diseaseCaseToUpdate.DiseaseCaseTabs)
            {
                _context.Entry(dct).Collection(u => u.Analyses).Load();
                _context.Entry(dct).Collection(u => u.Drugs).Load();
                _context.Entry(dct).Collection(u => u.Texts).Load();
                _context.Entry(dct).Collection(u => u.Pictures).Load();
                _context.Entry(dct).Collection(u => u.Videos).Load();
            }
            diseaseCaseToUpdate.Name = diseaseCase.Name;

            try
            {
                _context.Entry(diseaseCaseToUpdate).State = EntityState.Modified;
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
