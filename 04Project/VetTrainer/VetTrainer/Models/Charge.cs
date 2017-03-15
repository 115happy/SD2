namespace VetTrainer.Models
{

    public class Charge
    {
        public Charge()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        //*********************************************************************

        public virtual DiseaseCase DiseaseCase { get; set; }

    }
}
