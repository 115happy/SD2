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
    public class DiseaseCaseAddController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostDiseaseCaseAdd(DiseaseDto disease)
        {
            string msg = "";
            if (disease == null)
            {
                msg = "参数错误";
            }
            var diseaseToAdd = _context.Diseases.Find(disease.Id);
            _context.Entry(diseaseToAdd).Collection(u => u.DiseaseCases).Load();

            try
            {
                Charge charge = new Charge();
                charge.Amount = 0;
                charge.Description = "";
                charge.Name = diseaseToAdd.Name + "的费用";
                foreach (DiseaseCaseDto dcd in disease.DiseaseCases)
                {
                    var diseaseCaseToAdd = Mapper.Map<DiseaseCaseDto, DiseaseCase>(dcd);
                    foreach(DiseaseCaseTab dct in diseaseCaseToAdd.DiseaseCaseTabs)
                    {
                        switch(dct.Index)
                        {
                            case "2":
                                charge.Description += "接诊费用:" + 2 + "\n";
                                charge.Amount += 2;
                                break;
                                
                            case "3":
                                charge.Description += "检查费用:" + 3 + "\n";
                                charge.Amount += 3;
                                break;
                            case "4":
                                charge.Description += "诊断费用:" + 4 + "\n";
                                charge.Amount += 4;
                                break;
                            case "5":
                                charge.Description += "治疗费用:" + 5 + "\n";
                                charge.Amount += 5;
                                break;
                        }
                        foreach (Analysis a in dct.Analyses)
                        {
                            charge.Description += a.Name + ":" + a.Amount + "\n";
                            charge.Amount += a.Amount;
                        }
                        foreach(Drug d in dct.Drugs)
                        {
                            charge.Description += d.Name + ":" + d.Price + "\n";
                            charge.Amount += d.Price;
                        }
                    }
                    diseaseCaseToAdd.Charge = charge;
                    diseaseToAdd.DiseaseCases.Add(diseaseCaseToAdd);
                }
                _context.Diseases.Add(diseaseToAdd);
                _context.SaveChanges();
                msg = "添加成功";
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
