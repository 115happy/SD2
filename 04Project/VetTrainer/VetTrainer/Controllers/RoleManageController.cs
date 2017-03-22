using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;
using VetTrainer.Views.ViewModel;
using System.Data.Entity;
using System.Web.Script.Serialization;

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

        public JsonResult Test()
        {
            var searchText = Request.QueryString["searchText"];
            var SearchResults = SearchRoles(searchText);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = jss.Serialize(SearchResults);
            //var str = JsonConvert.SerializeObject(SearchResults[0]);
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        private static IList<Role> GetAllRoles()
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                List<Role> roles = context.Roles.ToList();
                return roles;
            }
        }
        private IList<Role> SearchRoles(string searchText)
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                List<Role> roles = context.Roles.Where(u => u.Name.Contains(searchText)).ToList();
                return roles;
            }
        }

    }
}