namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_charges")]
    public partial class tb_charges
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_charges()
        {
            tbref_disecase_charges = new HashSet<tbref_disecase_charges>();
        }

        [Key]
        public int charge_id { get; set; }

        [Required]
        [StringLength(45)]
        public string charge_name { get; set; }

        public decimal charge_amount { get; set; }

        [Required]
        [StringLength(3000)]
        public string charge_desp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecase_charges> tbref_disecase_charges { get; set; }
    }
}
