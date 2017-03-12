namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_dise_case")]
    public partial class tb_dise_case
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_dise_case()
        {
            tbref_diseases_disecase = new HashSet<tbref_diseases_disecase>();
            tbref_disecase_disecasetab = new HashSet<tbref_disecase_disecasetab>();
            tbref_disecase_charges = new HashSet<tbref_disecase_charges>();
        }

        [Key]
        public int case_id { get; set; }

        [Required]
        [StringLength(45)]
        public string case_name { get; set; }

        [Required]
        [StringLength(3000)]
        public string case_desp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_diseases_disecase> tbref_diseases_disecase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecase_disecasetab> tbref_disecase_disecasetab { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecase_charges> tbref_disecase_charges { get; set; }
    }
}
