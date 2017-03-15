namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Role
    {
        public Role()
        {
            Clinics = new List<Clinic>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RolePicUrl { get; set; }
        public virtual IList<Clinic> Clinics { get; set; }
    }
}
