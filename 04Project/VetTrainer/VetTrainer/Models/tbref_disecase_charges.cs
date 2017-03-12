namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tbref_disecase_charges")]
    public partial class tbref_disecase_charges
    {
        [Key]
        public int ref_id { get; set; }

        public int case_id { get; set; }

        public int charge_id { get; set; }

        public virtual tb_charges tb_charges { get; set; }

        public virtual tb_dise_case tb_dise_case { get; set; }
    }
}
