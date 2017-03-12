namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tbref_diseases_disecase")]
    public partial class tbref_diseases_disecase
    {
        [Key]
        public int ref_id { get; set; }

        public int disease_id { get; set; }

        public int case_id { get; set; }

        public virtual tb_dise_case tb_dise_case { get; set; }

        public virtual tb_diseases tb_diseases { get; set; }
    }
}
