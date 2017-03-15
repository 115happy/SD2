namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Picture
    {
        public Picture()
        {
            RelatedDiseaseCaseTabs = new List<DiseaseCaseTab>();
            RelatedInstruments = new List<Instrument>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        //*********************************************************************

        public int? RelatedClinicId { get; set; }
        public virtual Clinic RelatedClinic { get; set; }
        public virtual IList<DiseaseCaseTab> RelatedDiseaseCaseTabs { get; set; }
        public virtual IList<Instrument> RelatedInstruments { get; set; }
        public virtual IList<RPRecord> RelatedRPRecords { get; set; }
    }
}
