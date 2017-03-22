using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserAuthority Authority { get; set; }
    }
}