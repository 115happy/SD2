namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_analyses")]
    public partial class tb_analyses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_analyses()
        {
            tbref_disecasetab_analyses = new HashSet<tbref_disecasetab_analyses>();
        }

        [Key]
        public int analysis_id { get; set; }

        [Required]
        [StringLength(45)]
        public string analysis_name { get; set; }

        public decimal analysis_amount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_analyses> tbref_disecasetab_analyses { get; set; }
    }
}
