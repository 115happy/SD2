using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VetTrainer.Models;
using VetTrainer.Views.ViewModel;


namespace VetTrainer.Controllers
{
    public class ChargeManageController : Controller
    {
        // GET: ChargeManage
        public ActionResult Index()
        {
            ChargeViewModel model = new ChargeViewModel();
            model.charges = GetAllCharges();
            return View(model);
        }
        private IList<Charge> GetAllCharges()
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                List<Charge> charges = context.Charges.ToList();
                return charges;
            }
        }
    }
}