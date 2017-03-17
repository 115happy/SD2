using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;
using VetTrainer.Views.ViewModel;

namespace VetTrainer.Controllers
{
    public class RoleManageController : Controller
    {
        // GET: RoleManage
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
                List<Role> roles = context.Roles.ToList();
                return roles;
            }
        }
    }
}