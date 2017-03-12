namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_clinics")]
    public partial class tb_clinics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_clinics()
        {
            tbref_clinics_instruments = new HashSet<tbref_clinics_instruments>();
            tbref_roles_clinics_pics = new HashSet<tbref_roles_clinics_pics>();
            tbref_roles_clinics_texts = new HashSet<tbref_roles_clinics_texts>();
            tbref_roles_clinics_videos = new HashSet<tbref_roles_clinics_videos>();
        }

        [Key]
        public int clinic_id { get; set; }

        [Required]
        [StringLength(45)]
        public string clinic_name { get; set; }

        [Required]
        [StringLength(45)]
        public string clinic_desp { get; set; }

        public decimal? clinic_pos_x { get; set; }

        public decimal? clinic_pos_y { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_clinics_instruments> tbref_clinics_instruments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_roles_clinics_pics> tbref_roles_clinics_pics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_roles_clinics_texts> tbref_roles_clinics_texts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_roles_clinics_videos> tbref_roles_clinics_videos { get; set; }
    }
}
