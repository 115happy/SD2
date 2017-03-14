namespace VetTrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public partial class Text
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Text()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTab>();
            Instruments = new List<Instrument>();
        }

        public int TextId { get; set; }

        public string TextName { get; set; }

        public string TextContent { get; set; }


        public virtual IList<DiseaseCaseTab> DiseaseCaseTabs { get; set; }

        public virtual IList<Instrument> Instruments { get; set; }
    }
}
