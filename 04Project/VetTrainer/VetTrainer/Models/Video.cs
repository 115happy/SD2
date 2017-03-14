namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Video
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Video()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTab>();
            Instruments = new List<Instrument>();
        }

        public int VideoId { get; set; }

        public string VideoName { get; set; }

        public string VideoUrl { get; set; }

        public virtual IList<DiseaseCaseTab> DiseaseCaseTabs { get; set; }

        public virtual IList<Instrument> Instruments { get; set; }
    }
}
