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
    public class DrugModifyController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostDrugModify(DrugDto drug)
        {
            string msg = "";
            if (drug == null)
            {
                msg = "参数错误";
            }
            var drugToUpdate = _context.Drugs.Find(drug.Id);
            //userToUpdate = Mapper.Map<UserDto, User>(user);
            drugToUpdate.Name = drug.Name;
            drugToUpdate.Price = drug.Price;
            try
            {
                _context.Entry(drugToUpdate).State = EntityState.Modified;
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
