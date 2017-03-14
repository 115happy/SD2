namespace VetTrainer.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Authority { get; set; }

        public bool IsToRememberMe { get; set; }
    }
}
