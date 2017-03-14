namespace VetTrainer.Models
{

    public partial class Charge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Charge()
        {

        }

        public int ChargeId { get; set; }

        public string ChargeName { get; set; }

        public decimal ChargeAmount { get; set; }

        public string ChargeDescription { get; set; }

        public virtual DiseaseCase DiseaseCase { get; set; }

    }
}
