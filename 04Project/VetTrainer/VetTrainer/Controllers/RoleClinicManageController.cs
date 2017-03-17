using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;
using VetTrainer.Views.ViewModel;
using System.Data.Entity;

namespace VetTrainer.Controllers
{
    public class RoleClinicManageController : Controller
    {
        // GET: RoleClinicManage
        public ActionResult Index()
        {
            RolesViewModel model = new RolesViewModel();
            model.Roles = GetAllRoles();
            return View(model);
        }

        private static IList<Role> GetAllRoles()
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                List<Role> roles = context.Roles.Include(u => u.Clinics).ToList();
                foreach(Role r in roles)
                {
                    foreach(Clinic c in r.Clinics)
                    {
                        context.Entry(c).Collection(u => u.Texts).Load();
                        context.Entry(c).Collection(u => u.Pictures).Load();
                        context.Entry(c).Collection(u => u.Videos).Load();
                    }
                }
                return roles;
            }
        }
    }
}