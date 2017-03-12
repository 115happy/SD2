namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tbref_disetype_diseases")]
    public partial class tbref_disetype_diseases
    {
        [Key]
        public int ref_id { get; set; }

        public int type_id { get; set; }

        public int disease_id { get; set; }

        public virtual tb_dise_type tb_dise_type { get; set; }

        public virtual tb_diseases tb_diseases { get; set; }
    }
}
