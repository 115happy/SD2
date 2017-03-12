namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_dise_type")]
    public partial class tb_dise_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_dise_type()
        {
            tbref_disetype_diseases = new HashSet<tbref_disetype_diseases>();
        }

        [Key]
        public int type_id { get; set; }

        [Required]
        [StringLength(45)]
        public string type_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disetype_diseases> tbref_disetype_diseases { get; set; }
    }
}
