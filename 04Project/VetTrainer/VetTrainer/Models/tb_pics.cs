namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_pics")]
    public partial class tb_pics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_pics()
        {
            tbref_disecasetab_pics = new HashSet<tbref_disecasetab_pics>();
            tbref_instruments_pics = new HashSet<tbref_instruments_pics>();
            tbref_roles_clinics_pics = new HashSet<tbref_roles_clinics_pics>();
        }

        [Key]
        public int pic_id { get; set; }

        [Required]
        [StringLength(45)]
        public string pic_name { get; set; }

        [Required]
        [StringLength(3000)]
        public string pic_url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_pics> tbref_disecasetab_pics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_instruments_pics> tbref_instruments_pics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_roles_clinics_pics> tbref_roles_clinics_pics { get; set; }
    }
}
