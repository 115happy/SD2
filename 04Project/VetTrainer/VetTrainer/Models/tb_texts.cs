namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_texts")]
    public partial class tb_texts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_texts()
        {
            tbref_disecasetab_texts = new HashSet<tbref_disecasetab_texts>();
            tbref_instruments_texts = new HashSet<tbref_instruments_texts>();
            tbref_roles_clinics_texts = new HashSet<tbref_roles_clinics_texts>();
        }

        [Key]
        public int text_id { get; set; }

        [Required]
        [StringLength(45)]
        public string text_name { get; set; }

        [Required]
        [StringLength(3000)]
        public string text_content { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_texts> tbref_disecasetab_texts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_instruments_texts> tbref_instruments_texts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_roles_clinics_texts> tbref_roles_clinics_texts { get; set; }
    }
}
