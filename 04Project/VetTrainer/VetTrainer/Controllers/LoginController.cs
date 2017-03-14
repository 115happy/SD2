﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VetTrainer.Models;

namespace VetTrainer.Controllers
{
    [RoutePrefix("Login")]
    public class LoginController : Controller
    {
        private VetAppDBContext _context;

        public LoginController()
        {
            _context = new VetAppDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("~/")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [Route("~/")]
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, user.IsToRememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "用户名和密码不匹配，请检查！");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

        /// <summary>
        /// Checks if user with given password exists in the database.
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password"User password</param>
        /// <returns></returns>
        public static bool IsValid(string username, string password)
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {

                // var clinics = context.Clinics.Include(c=>c.Instruments).ToList();
                var users = context.Users.ToList();
                string encryptedPassword = Utilities.Encoder.Encode(password);
                User foundUser = users.SingleOrDefault(u =>
                    u.UserName == username && u.Password == encryptedPassword);
                if (foundUser != null) return true;
                return false;
            }
        }
        // u => u*u
        /*
         int Multiply(int u)
         {
         return u * u;
         }
         SingleOrDefault(Func<T> (T, bool)) 

        public delegate int multiply(int);
        multiply +=u=>u*u;
        multiply(6);
         */
    }
}