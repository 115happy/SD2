using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;

namespace VetTrainer.Controllers
{
    public class UserManagementController : Controller
    {
        VetAppDBContext _context = new VetAppDBContext();
        // GET: UserManagement
        public ActionResult Index(string Name)
        {
            User userToUpdate = _context.Users.Where(u => u.Name == Name).FirstOrDefault();
            ViewBag.User = userToUpdate;
            return View();
        }
    }
}