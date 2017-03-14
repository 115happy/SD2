namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Disease
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disease()
        {
            DiseaseCases = new List<DiseaseCase>();
        }

        public int DiseaseId { get; set; }

        public string DiseaseName { get; set; }

        public virtual IList<DiseaseCase> DiseaseCases { get; set; }

        public virtual DiseaseType DiseaseType { get; set; }
    }
}
