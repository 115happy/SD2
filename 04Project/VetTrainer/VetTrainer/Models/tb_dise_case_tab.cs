namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_dise_case_tab")]
    public partial class tb_dise_case_tab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_dise_case_tab()
        {
            tbref_disecase_disecasetab = new HashSet<tbref_disecase_disecasetab>();
            tbref_disecasetab_analyses = new HashSet<tbref_disecasetab_analyses>();
            tbref_disecasetab_drugs = new HashSet<tbref_disecasetab_drugs>();
            tbref_disecasetab_pics = new HashSet<tbref_disecasetab_pics>();
            tbref_disecasetab_texts = new HashSet<tbref_disecasetab_texts>();
            tbref_disecasetab_videos = new HashSet<tbref_disecasetab_videos>();
        }

        [Key]
        public int tab_id { get; set; }

        [Required]
        [StringLength(45)]
        public string tab_index { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecase_disecasetab> tbref_disecase_disecasetab { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_analyses> tbref_disecasetab_analyses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_drugs> tbref_disecasetab_drugs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_pics> tbref_disecasetab_pics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_texts> tbref_disecasetab_texts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_videos> tbref_disecasetab_videos { get; set; }
    }
}
