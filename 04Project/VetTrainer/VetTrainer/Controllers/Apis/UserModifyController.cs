using AutoMapper;
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
using VetTrainer.Utilities;

namespace VetTrainer.Controllers.Apis
{
    public class UserModifyController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult PostUserModify(UserIntactDto user)
        {
            string msg = "";
            if (user == null)
            {
                msg = "参数错误";
            }

            var userToUpdate = _context.Users.Find(user.Id);
            if (userToUpdate.Password == Encoder.Encode(user.Password))
            {
                msg = "请输入不同的密码";
            }
            else
            {
                try
                {
                    Mapper.Map(user, userToUpdate);
                    userToUpdate.Password = Encoder.Encode(user.Password);
                    _context.SaveChanges();
                    msg = "修改成功";
                }
                catch (RetryLimitExceededException)
                {
                    msg = "网络故障";
                }
            }

            //var userToUpdate = _context.Users.Find(user.Id);
            //userToUpdate = Mapper.Map<UserIntactDto, User>(user);
            //userToUpdate.Password = Encoder.Encode(user.Password);
            //userToUpdate.Name = user.Name;
            //userToUpdate.Authority = user.Authority;
            //userToUpdate.IsToRememberMe = user.IsToRememberMe;
            //try
            //{
            //    _context.Entry(userToUpdate).State = EntityState.Modified;
            //    _context.SaveChanges();
            //    msg = "修改成功";
            //}
            //catch (RetryLimitExceededException)
            //{
            //    msg = "网络故障";
            //}
            //var str = string.Format("{\'Message\': \'{0}\', \'Data\':  \'null\'}", msg);
            var str = $"{{'Message' : '{msg}', 'Data' : 'null'}}";
            str = str.Replace('\'', '"');
            //var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
            return Ok(str);
        }
    }
}
