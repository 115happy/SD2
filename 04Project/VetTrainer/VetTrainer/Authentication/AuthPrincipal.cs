using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Authentication
{
    public class AuthPrincipal : IPrincipal
    {
        public AuthPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public UserDto User { get; set; }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}