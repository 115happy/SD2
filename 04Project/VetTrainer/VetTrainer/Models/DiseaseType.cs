namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class DiseaseType
    {
        public DiseaseType()
        {
            Diseases = new List<Disease>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Disease> Diseases { get; set; }
    }
}
