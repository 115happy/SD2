namespace VetTrainer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Analysis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Analysis()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTab>();
        }
        
        public int AnalysisId { get; set; }

        public string AnalysisName { get; set; }

        public decimal AnalysisAmount { get; set; }

        public virtual IList<DiseaseCaseTab> DiseaseCaseTabs { get; set; }
    }
}
