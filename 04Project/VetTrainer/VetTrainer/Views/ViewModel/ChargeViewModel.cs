using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetTrainer.Models;


namespace VetTrainer.Views.ViewModel
{
    public class ChargeViewModel
    {
        public IList<Charge> charges = new List<Charge>();
    }
}