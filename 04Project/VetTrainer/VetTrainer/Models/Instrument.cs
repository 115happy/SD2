namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Instrument()
        {
            Clinics = new List<Clinic>();
            Texts = new List<Text>();
            Pictures = new List<Picture>();
            Videos = new List<Video>();
        }

        public int InstrumentId { get; set; }

        public string InstrumentName { get; set; }

        public string InstrumentDescription { get; set; }

        public string ModelUrl { get; set; }

        public virtual IList<Clinic> Clinics { get; set; }

        public virtual IList<Text> Texts { get; set; }

        public virtual IList<Picture> Pictures { get; set; }

        public virtual IList<Video> Videos { get; set; }

    }
}
