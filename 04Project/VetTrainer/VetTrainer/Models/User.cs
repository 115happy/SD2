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

        [Display(Name = Views.Strings.Login.LblUsername)]
        public string Name { get; set; }

        [Display(Name = Views.Strings.Login.LblPassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public UserAuthority Authority { get; set; }

        [Display(Name = Views.Strings.Login.LblIsToRememberMe)]
        public bool IsToRememberMe { get; set; }
    }
}
