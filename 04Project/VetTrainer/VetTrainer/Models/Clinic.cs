namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_clinics")]
    public partial class Clinic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clinic()
        {
            Instruments = new List<Instrument>();
            Texts = new List<Text>();
            Pictures = new List<Picture>();
            Videos = new List<Video>();
        }

        public int ClinicId { get; set; }

        public string ClinicName { get; set; }

        public string ClinicDescription { get; set; }

        public decimal? ClinicPositionX { get; set; }

        public decimal? ClinicPositionY { get; set; }

        public virtual IList<Text> Texts { get; set; }
        public virtual IList<Picture> Pictures { get; set; }

        public virtual IList<Video> Videos { get; set; }

        public virtual IList<Instrument> Instruments { get; set; }

    }
}
