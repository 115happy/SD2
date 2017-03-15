namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Drug
    {
        public Drug()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTab>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //*********************************************************************

        public virtual IList<DiseaseCaseTab> DiseaseCaseTabs { get; set; }

    }
}
