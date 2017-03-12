namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_drugs")]
    public partial class tb_drugs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_drugs()
        {
            tbref_disecasetab_drugs = new HashSet<tbref_disecasetab_drugs>();
        }

        [Key]
        public int drug_id { get; set; }

        [Required]
        [StringLength(45)]
        public string drug_name { get; set; }

        public decimal drug_price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_drugs> tbref_disecasetab_drugs { get; set; }
    }
}
