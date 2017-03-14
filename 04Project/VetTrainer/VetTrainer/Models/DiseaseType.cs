namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DiseaseType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiseaseType()
        {
            Diseases = new List<Disease>();
        }

        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public virtual IList<Disease> Diseases { get; set; }
    }
}
