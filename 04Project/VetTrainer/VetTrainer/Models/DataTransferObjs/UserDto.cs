using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class UserDto
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        //public UserAuthority Authority { get; set; }

        [Display(Name = Views.Strings.Login.LblUsername)]
        public string Name { get; set; }

        // password 和 istorememberme 应该不要
        [Display(Name = Views.Strings.Login.LblPassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public UserAuthority Authority { get; set; }

        [Display(Name = Views.Strings.Login.LblIsToRememberMe)]
        public bool IsToRememberMe { get; set; }
    }
}