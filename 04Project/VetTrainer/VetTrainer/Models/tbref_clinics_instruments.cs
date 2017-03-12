namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tbref_clinics_instruments")]
    public partial class tbref_clinics_instruments
    {
        [Key]
        public int ref_id { get; set; }

        public int clinic_id { get; set; }

        public int instrument_id { get; set; }

        public virtual tb_clinics tb_clinics { get; set; }

        public virtual tb_instruments tb_instruments { get; set; }
    }
}
