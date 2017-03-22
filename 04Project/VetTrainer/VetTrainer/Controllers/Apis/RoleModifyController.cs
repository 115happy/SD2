using System.Web.Http;
using VetTrainer.Models;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Data.Entity;
using VetTrainer.Models.DataTransferObjs;
using System.Text;

namespace VetTrainer.Controllers.Apis
{
    public class RoleModifyController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostRoleModify(RoleDto role)
        {
            string msg = "";
            if (role==null)
            {
                msg = "参数错误";
            }
            var roleToUpdate = _context.Roles.Find(role.Id);
            roleToUpdate.Name = role.Name;
            roleToUpdate.Description = role.Description;
            roleToUpdate.RolePicUrl = role.RolePicUrl;
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Entry(roleToUpdate).State = EntityState.Modified;
                    _context.SaveChanges();
                    msg = "修改成功";
                }
            }catch(RetryLimitExceededException)
            {
                msg = "网络故障";
            }
            var str = "[{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }]";
            return Ok(str);
        }
    }
}
