namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vet_app.tb_users")]
    public partial class tb_users
    {
        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(45)]
        public string username { get; set; }

        [Required]
        [StringLength(60)]
        public string password { get; set; }

        [Required]
        [StringLength(45)]
        public string authority { get; set; }
    }
}
