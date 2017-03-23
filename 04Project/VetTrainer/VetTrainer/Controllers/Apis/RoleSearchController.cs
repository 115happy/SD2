using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;
using System.Data.Entity.Infrastructure;
using System.Web.Script.Serialization;

namespace VetTrainer.Controllers.Apis
{
    public class RoleSearchController : ApiController
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
            var roleDtos = new List<RoleDto>();
            try
            {
                List<Role> roles = new List<Role>();
                roles = _context.Roles.ToList();
                foreach (Role role in roles)
                {
                    var roDto = Mapper.Map<Role, RoleDto>(role);
                    roleDtos.Add(roDto);
                }
                if (roleDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }
            catch (RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(roleDtos) + " }";
            return Ok(str);
        }
        //获取查询角色信息结果api
        public IHttpActionResult GetSearchResult(string searchText)
        {
            string msg = "";
            var roleDtos = new List<RoleDto>();
            try
            {
                List<Role> roles = new List<Role>();
                if(searchText==null||searchText.Trim()=="")
                {
                    roles = _context.Roles.ToList();
                }else
                {
                    roles = _context.Roles.Where(u => u.Name.Contains(searchText)).ToList();
                }
                foreach (Role role in roles)
                {
                    var roDto = Mapper.Map<Role, RoleDto>(role);
                    roleDtos.Add(roDto);
                }
                if (roleDtos.Count > 0)
                    msg = "查找成功";
                else
                    msg = "没有结果";

            }catch(RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : " + jss.Serialize(roleDtos) + " }";
            return Ok(str);
        }
    }
}