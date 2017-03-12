namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_roles")]
    public partial class tb_roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_roles()
        {
            tbref_roles_clinics_pics = new HashSet<tbref_roles_clinics_pics>();
            tbref_roles_clinics_texts = new HashSet<tbref_roles_clinics_texts>();
            tbref_roles_clinics_videos = new HashSet<tbref_roles_clinics_videos>();
        }

        [Key]
        public int role_id { get; set; }

        [Required]
        [StringLength(45)]
        public string role_name { get; set; }

        [Required]
        [StringLength(3000)]
        public string role_desp { get; set; }

        [Required]
        [StringLength(300)]
        public string role_pic_url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_roles_clinics_pics> tbref_roles_clinics_pics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_roles_clinics_texts> tbref_roles_clinics_texts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_roles_clinics_videos> tbref_roles_clinics_videos { get; set; }
    }
}
