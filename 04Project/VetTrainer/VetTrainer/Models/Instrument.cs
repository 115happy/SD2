namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Instrument
    {
        public Instrument()
        {
            Clinics = new List<Clinic>();
            Texts = new List<Text>();
            Pictures = new List<Picture>();
            Videos = new List<Video>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ModelUrl { get; set; }
        public virtual IList<Text> Texts { get; set; }
        public virtual IList<Picture> Pictures { get; set; }
        public virtual IList<Video> Videos { get; set; }

        //*********************************************************************

        public virtual IList<Clinic> Clinics { get; set; }

    }
}
