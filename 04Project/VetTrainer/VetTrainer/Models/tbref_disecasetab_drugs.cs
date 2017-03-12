namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tbref_disecasetab_drugs")]
    public partial class tbref_disecasetab_drugs
    {
        [Key]
        public int ref_id { get; set; }

        public int tab_id { get; set; }

        public int drug_id { get; set; }

        public virtual tb_dise_case_tab tb_dise_case_tab { get; set; }

        public virtual tb_drugs tb_drugs { get; set; }
    }
}
