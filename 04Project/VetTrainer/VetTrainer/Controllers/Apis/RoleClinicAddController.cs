using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Controllers.Apis
{
    public class RoleClinicAddController : ApiController
    {
        VetAppDBContext _context = new VetAppDBContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult PostRoleClinicAdd(RPRecordDto rpRecord)
        {
            string msg = "";
            var roleToAdd = _context.Roles.Find(rpRecord.RoleId);
            var clinicToAdd = _context.Clinics.Find(rpRecord.ClinicId);
            if (rpRecord == null || roleToAdd == null || clinicToAdd == null)
            {
                msg = "参数错误";
            }
            var rpRecordToAdd = Mapper.Map<RPRecordDto, RPRecord>(rpRecord);
            try
            {
                _context.RPRecords.Add(rpRecordToAdd);
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
