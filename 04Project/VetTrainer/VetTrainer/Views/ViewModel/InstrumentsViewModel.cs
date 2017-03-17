using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetTrainer.Models;

namespace VetTrainer.Views.ViewModel
{
    public class InstrumentsViewModel
    {
        public IList<Instrument> instruments = new List<Instrument>();
    }
}