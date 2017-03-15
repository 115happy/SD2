namespace VetTrainer.Models
{
    using System.Collections.Generic;

    public class DiseaseCase
    {
        public DiseaseCase()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTab>();
            Diseases = new List<Disease>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public virtual IList<DiseaseCaseTab> DiseaseCaseTabs { get; set; }
        public virtual Charge Charge { get; set; }

        //*********************************************************************

        public virtual IList<Disease> Diseases { get; set; }
    }
}
