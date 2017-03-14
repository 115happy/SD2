namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Drug
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drug()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTab>();
        }

        public int DrugId { get; set; }

        public string DrugName { get; set; }

        public decimal DrugPrice { get; set; }

        public virtual IList<DiseaseCaseTab> DiseaseCaseTabs { get; set; }

    }
}
