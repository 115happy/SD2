using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;
using System.Data.Entity;

namespace VetTrainer.Controllers
{
    public class RolePlayController : Controller
    {
        // GET: RolePlay
        public ActionResult Index()
        {
            ViewBag.Roles = GetAllRoles();
            return View();
        }
        public ActionResult ClinicSelect()
        {
            int Id = int.Parse(Request.QueryString["roleId"]);
            ViewBag.Role = GetRole(Id);
            return View();
        }
        public ActionResult Clinic()
        {
            int roleId = int.Parse(Request.QueryString["roleId"]);
            int clinicId = int.Parse(Request.QueryString["clinicId"]);
            ViewBag.rpRecord = GetRPRecord(roleId, clinicId);

            return View();
        }

        public RPRecord GetRPRecord(int roleId,int clinicId)
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                RPRecord rpRecord = context.RPRecords.Include(rp => rp.Pictures).Include(rp => rp.Videos)
                    .SingleOrDefault(u => u.RoleId == roleId && u.ClinicId == clinicId);
                return rpRecord;
            }  
        }

        public Role GetRole(int roleId)
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                Role role = context.Roles.Include(r=>r.Clinics).SingleOrDefault(u => u.Id == roleId);
                return role;
            }
        }

        //var users = context.Users.ToList();
        //string encryptedPassword = Utilities.Encoder.Encode(password);
        //User foundUser = users.SingleOrDefault(u =>
        //    u.Name == username && u.Password == encryptedPassword);
        //        if (foundUser != null) return true;
        //        return false;
        public static List<Role> GetAllRoles()
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {

                // var clinics = context.Clinics.Include(c=>c.Instruments).ToList();
                var roles = context.Roles.ToList();
                return roles;
            }
        }
    }
}