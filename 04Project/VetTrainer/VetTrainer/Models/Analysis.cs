namespace VetTrainer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Analysis
    {
        public Analysis()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTab>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }

        //*********************************************************************

        public virtual IList<DiseaseCaseTab> DiseaseCaseTabs { get; set; }
    }
}
