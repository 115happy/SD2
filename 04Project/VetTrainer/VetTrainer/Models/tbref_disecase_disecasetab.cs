namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tbref_disecase_disecasetab")]
    public partial class tbref_disecase_disecasetab
    {
        [Key]
        public int ref_id { get; set; }

        public int case_id { get; set; }

        public int tab_id { get; set; }

        public virtual tb_dise_case tb_dise_case { get; set; }

        public virtual tb_dise_case_tab tb_dise_case_tab { get; set; }
    }
}
