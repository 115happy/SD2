namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tbref_roles_clinics_videos")]
    public partial class tbref_roles_clinics_videos
    {
        [Key]
        [Column(Order = 0)]
        public int ref_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int role_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int clinic_id { get; set; }

        public int video_id { get; set; }

        public virtual tb_clinics tb_clinics { get; set; }

        public virtual tb_roles tb_roles { get; set; }

        public virtual tb_videos tb_videos { get; set; }
    }
}
