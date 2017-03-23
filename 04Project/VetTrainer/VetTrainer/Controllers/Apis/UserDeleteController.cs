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
    public class UserDeleteController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostUserDelete(UserIntactDto user)
        {
            string msg = "";
            if (user == null)
            {
                msg = "参数错误";
            }
            var userToDelete = _context.Users.Find(user.Id);
            if(userToDelete==null)
            {
                msg = "删除失败，该用户不存在";
            }else
            {
                try
                {
                    _context.Users.Remove(userToDelete);
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
