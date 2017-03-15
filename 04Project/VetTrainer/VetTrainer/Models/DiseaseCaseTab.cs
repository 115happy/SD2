namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class DiseaseCaseTab
    {
        public DiseaseCaseTab()
        {
            Analyses = new List<Analysis>();
            Drugs = new List<Drug>();
            Texts = new List<Text>();
            Pictures = new List<Picture>();
            Videos = new List<Video>();
        }

        public int Id { get; set; }
        public string Index { get; set; }
        public virtual IList<Analysis> Analyses { get; set; }
        public virtual IList<Drug> Drugs { get; set; }
        public virtual IList<Text> Texts { get; set; }
        public virtual IList<Picture> Pictures { get; set; }
        public virtual IList<Video> Videos { get; set; }

        //*********************************************************************

        public int DiseaseCaseId { get; set; }
        public virtual DiseaseCase DiseaseCase { get; set; }
    }
}
