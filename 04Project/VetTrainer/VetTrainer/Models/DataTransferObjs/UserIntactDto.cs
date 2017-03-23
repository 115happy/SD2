using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class UserIntactDto
    {
        public int Id { get; set; }

        [Display(Name = Views.Strings.Login.LblUsername)]
        public string Name { get; set; }

        public string Password { get; set; }
        public UserAuthority Authority { get; set; }

        [Display(Name = Views.Strings.Login.LblIsToRememberMe)]
        public bool IsToRememberMe { get; set; }
    }
}