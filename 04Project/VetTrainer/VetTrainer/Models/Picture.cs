namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Picture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Picture()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTab>();
            Instruments = new List<Instrument>();
        }
        public int PicId { get; set; }

        public string PicName { get; set; }

        public string PicUrl { get; set; }

        public virtual IList<DiseaseCaseTab> DiseaseCaseTabs { get; set; }

        public virtual IList<Instrument> Instruments { get; set; }
    }
}
