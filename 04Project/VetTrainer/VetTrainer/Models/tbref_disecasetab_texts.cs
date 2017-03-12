namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tbref_disecasetab_texts")]
    public partial class tbref_disecasetab_texts
    {
        [Key]
        public int ref_id { get; set; }

        public int tab_id { get; set; }

        public int text_id { get; set; }

        public virtual tb_dise_case_tab tb_dise_case_tab { get; set; }

        public virtual tb_texts tb_texts { get; set; }
    }
}
