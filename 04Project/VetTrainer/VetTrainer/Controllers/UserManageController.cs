using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;
using VetTrainer.Views.ViewModel;

namespace VetTrainer.Controllers
{
    public class UserManageController : Controller
    {
        // GET: UserManage
        public ActionResult Index()
        {
            UsersViewModel model = new UsersViewModel();
            model.users = GetAllUser();
            return View(model);
        }

        private static IList<User> GetAllUser()
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                List<User> users = context.Users.ToList();
                return users;
            }
        }
    }
}