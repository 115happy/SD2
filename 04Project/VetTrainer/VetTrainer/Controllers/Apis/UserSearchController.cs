using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Controllers.Apis
{
    public class UserSearchController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();
        // GET: RoleSearch
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetSearchResult()
        {
            string msg = "";
            var userDtos = new List<UserIntactDto>();
            try
            {
                List<User> users = new List<User>();
                users = _context.Users.ToList();
                foreach (User user in users)
                {
                    var userDto = Mapper.Map<User, UserIntactDto>(user);
                    userDtos.Add(userDto);
                }
                if (userDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(userDtos) + " }";
            return Ok(str);
        }
        //获取查询用户信息结果api
        public IHttpActionResult GetSearchResult(string searchText)
        {
            string msg = "";
            var userDtos = new List<UserIntactDto>();
            try
            {
                List<User> users = new List<User>();
                if (searchText == null || searchText.Trim() == "")
                {
                    users = _context.Users.ToList();
                }
                else
                {
                    users = _context.Users.Where(u => u.Name.Contains(searchText)).ToList();
                }
                foreach (User user in users)
                {
                    var userDto = Mapper.Map<User, UserIntactDto>(user);
                    userDtos.Add(userDto);
                }
                if (userDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(userDtos) + " }";
            return Ok(str);
        }
    }
}
