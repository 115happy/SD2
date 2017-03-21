using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using VetTrainer.Models;

namespace VetTrainer
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    //public class VetAppUserStore : UserStore<VetAppUser>
    //{
    //    public VetAppUserStore(VetAppDBContext context)
    //        : base(context)
    //    {
    //    }
    //}

    //public class VetAppUserManager : UserManager<VetAppUser>
    //{
    //    public VetAppUserManager(IUserStore<VetAppUser> store) : base(store)
    //    {
    //    }
    //}
}
