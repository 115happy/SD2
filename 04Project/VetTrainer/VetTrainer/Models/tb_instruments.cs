namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_instruments")]
    public partial class tb_instruments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_instruments()
        {
            tbref_clinics_instruments = new HashSet<tbref_clinics_instruments>();
            tbref_instruments_pics = new HashSet<tbref_instruments_pics>();
            tbref_instruments_texts = new HashSet<tbref_instruments_texts>();
            tbref_instruments_videos = new HashSet<tbref_instruments_videos>();
        }

        [Key]
        public int instrument_id { get; set; }

        [Required]
        [StringLength(45)]
        public string instument_name { get; set; }

        [Required]
        [StringLength(45)]
        public string instrument_desp { get; set; }

        [Required]
        [StringLength(45)]
        public string model_url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_clinics_instruments> tbref_clinics_instruments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_instruments_pics> tbref_instruments_pics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_instruments_texts> tbref_instruments_texts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbref_instruments_videos> tbref_instruments_videos { get; set; }
    }
}
