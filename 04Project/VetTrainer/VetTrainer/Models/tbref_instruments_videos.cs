namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tbref_instruments_videos")]
    public partial class tbref_instruments_videos
    {
        [Key]
        public int ref_id { get; set; }

        public int instrument_id { get; set; }

        public int video_id { get; set; }

        public virtual tb_instruments tb_instruments { get; set; }

        public virtual tb_videos tb_videos { get; set; }
    }
}
