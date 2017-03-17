using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetTrainer.Models;

namespace VetTrainer.Views.ViewModel
{
    public class SelDiseaseCaseViewModel
    {
        public IEnumerable<DiseaseType> DiseaseTypes{ get; set; }
        public IEnumerable<Disease> Diseases { get; set; }
        public IEnumerable<DiseaseCase> DiseaseCases { get; set; }
    }
}