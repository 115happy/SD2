using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;
using AutoMapper;

namespace VetTrainer.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : Controller
    {
        VetAppDBContext _context = new VetAppDBContext();

        [Route]
        public ActionResult Index(string Name)
        {
            User userToUpdate = _context.Users.Where(u => u.Name == Name).FirstOrDefault();
            UserIntactDto userToUpdateIntactDto = Mapper.Map<User, UserIntactDto>(userToUpdate);

            // Protect the password
            userToUpdateIntactDto.Password = string.Empty;

            return View(userToUpdateIntactDto);
        }
    }
}