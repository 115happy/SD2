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
    
    public class DrugDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult PostDrugDelete(DrugDto drug)
        {
            string msg = "";
            if (drug == null)
            {
                msg = "参数错误";
            }
            var drugToDelete = _context.Drugs.Find(drug.Id);
            if (drugToDelete == null)
            {
                msg = "删除失败，该药品不存在";
            }
            else
            {
                try
                {
                    _context.Drugs.Remove(drugToDelete);
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
