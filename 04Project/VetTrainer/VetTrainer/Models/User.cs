namespace VetTrainer.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    //public class VetAppUser : IdentityUser
    //{

    //}

    //public class VetAppRole : IdentityRole
    //{
    //    public VetAppRole()
    //    {

    //    }
    //}

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
