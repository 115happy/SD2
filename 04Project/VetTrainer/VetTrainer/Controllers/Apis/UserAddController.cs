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
    public class UserAddController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostUserAdd(UserIntactDto user)
        {
            string msg = "";
            if (user == null)
            {
                msg = "参数错误";
            }
            var userToAdd = Mapper.Map<UserIntactDto, User>(user);
            userToAdd.Password = Encoder.Encode(userToAdd.Password);
            try
            {
                _context.Users.Add(userToAdd);
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
