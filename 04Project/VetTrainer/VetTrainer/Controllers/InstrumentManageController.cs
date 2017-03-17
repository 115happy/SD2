using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VetTrainer.Models;
using System.Data.Entity;
using VetTrainer.Views.ViewModel;

namespace VetTrainer.Controllers
{
    public class InstrumentManageController : Controller
    {
        // GET: InstrumentManage
        public ActionResult Index()
        {
            ClinicsViewModel model = new ClinicsViewModel();
            model.clinics = GetAllInstrument();
            return View(model);
        }

        private IList<Clinic> GetAllInstrument()
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {
                List<Clinic> clinics = context.Clinics.Include(u => u.Instruments)
                    .Include(u => u.Texts).Include(u => u.Pictures)
                    .Include(u => u.Videos).ToList();
                foreach(Clinic c in clinics)
                {
                    foreach (Instrument i in c.Instruments)
                    {
                        context.Entry(i).Collection(u => u.Texts).Load();
                        context.Entry(i).Collection(u => u.Pictures).Load();
                        context.Entry(i).Collection(u => u.Videos).Load();
                    }
                }
                return clinics;
            }
        }
    }
}