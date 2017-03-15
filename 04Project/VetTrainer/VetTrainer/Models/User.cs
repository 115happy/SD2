namespace VetTrainer.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum UserAuthority
    {
        User = 0,
        Admin = 1,
        SuperAdmin = 2
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public UserAuthority Authority { get; set; }
        public bool IsToRememberMe { get; set; }
    }
}
