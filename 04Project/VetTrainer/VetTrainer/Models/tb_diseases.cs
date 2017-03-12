namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_diseases")]
    public partial class tb_diseases
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_diseases()
        {
            tbref_diseases_disecase = new HashSet<tbref_diseases_disecase>();
            tbref_disetype_diseases = new HashSet<tbref_disetype_diseases>();
        }

        [Key]
        public int disease_id { get; set; }

        [Required]
        [StringLength(45)]
        public string disease_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_diseases_disecase> tbref_diseases_disecase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disetype_diseases> tbref_disetype_diseases { get; set; }
    }
}
