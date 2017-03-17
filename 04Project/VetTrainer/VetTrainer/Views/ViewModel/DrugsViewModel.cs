using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetTrainer.Models;

namespace VetTrainer.Views.ViewModel
{
    public class DrugsViewModel
    {
        public IList<Drug> drugs = new List<Drug>();
    }
}