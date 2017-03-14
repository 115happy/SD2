namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DiseaseCaseTab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiseaseCaseTab()
        {
            Analysiss = new List<Analysis>();
            Drugs = new List<Drug>();
            Texts = new List<Text>();
            Pictures = new List<Picture>();
            Videos = new List<Video>();
        }

        public int TabId { get; set; }

        public string TabIndex { get; set; }

        public virtual IList<Analysis> Analysiss { get; set; }

        public virtual IList<Drug> Drugs { get; set; }

        public virtual IList<Text> Texts { get; set; }

        public virtual IList<Picture> Pictures { get; set; }

        public virtual IList<Video> Videos { get; set; }

        public virtual DiseaseCase DiseaseCase { get; set; }
    }
}
