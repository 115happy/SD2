namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Disease
    {
        public Disease()
        {
            DiseaseCases = new List<DiseaseCase>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<DiseaseCase> DiseaseCases { get; set; }

        //*********************************************************************

        public int DiseaseTypeId { get; set; }
        public virtual DiseaseType DiseaseType { get; set; }
    }
}
