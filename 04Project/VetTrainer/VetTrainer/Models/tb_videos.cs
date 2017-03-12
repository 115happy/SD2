namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_videos")]
    public partial class tb_videos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_videos()
        {
            tbref_disecasetab_videos = new HashSet<tbref_disecasetab_videos>();
            tbref_instruments_videos = new HashSet<tbref_instruments_videos>();
            tbref_roles_clinics_videos = new HashSet<tbref_roles_clinics_videos>();
        }

        [Key]
        public int video_id { get; set; }

        [Required]
        [StringLength(45)]
        public string video_name { get; set; }

        [Required]
        [StringLength(3000)]
        public string video_url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_disecasetab_videos> tbref_disecasetab_videos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_instruments_videos> tbref_instruments_videos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_roles_clinics_videos> tbref_roles_clinics_videos { get; set; }
    }
}
