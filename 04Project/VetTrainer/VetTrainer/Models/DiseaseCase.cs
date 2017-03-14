namespace VetTrainer.Models
{
    using System.Collections.Generic;

    public partial class DiseaseCase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiseaseCase()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTab>();
            Diseases = new List<Disease>();
        }

        public int CaseId { get; set; }

        public string CaseName { get; set; }

        public string CaseDiscription { get; set; }

        public virtual IList<DiseaseCaseTab> DiseaseCaseTabs { get; set; }

        public virtual IList<Disease> Diseases { get; set; }

        public virtual Charge Charge { get; set; }

        public virtual DiseaseType DiseaseType { get; set; }
    }
}
