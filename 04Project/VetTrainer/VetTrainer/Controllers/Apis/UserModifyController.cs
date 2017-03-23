﻿using AutoMapper;
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

        public IHttpActionResult PostUserModify(UserIntactDto user)
        {
            string msg = "";
            if (user == null)
            {
                msg = "参数错误";
            }
            var userToUpdate = _context.Users.Find(user.Id);
            //userToUpdate = Mapper.Map<UserDto, User>(user);
            userToUpdate.Name = user.Name;
            userToUpdate.Password = Encoder.Encode(user.Password);
            userToUpdate.Authority = user.Authority;
            userToUpdate.IsToRememberMe = user.IsToRememberMe;
            try
            {
                _context.Entry(userToUpdate).State = EntityState.Modified;
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
