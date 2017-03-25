using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Authentication
{
    public class AdminExclusiveAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpCookie authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // Get the forms authentication ticket.
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");
                var principal = new AuthPrincipal(identity);

                // Get the custom user data encrypted in the ticket.
                if (filterContext.HttpContext.User.Identity is FormsIdentity)
                {
                    string userData = ((FormsIdentity)(filterContext.HttpContext.User.Identity)).Ticket.UserData;

                    // Deserialize the json data and set it on the custom principal.
                    var serializer = new JavaScriptSerializer();
                    principal.User = (UserDto)serializer.Deserialize(userData, typeof(UserDto));
                }
                else
                {
                    principal.User = (filterContext.HttpContext.User as dynamic).User;
                }

                // Page level authentication
                if (principal.User.Authority != Models.UserAuthority.Admin)
                {

                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                                        { "action", "ErrorAdminRequired" },
                                        { "controller", "ErrorPages" }
                        });
                }

                // Set the context user as the authPrincipal hence views can retrive user data.
                filterContext.HttpContext.User = principal;
            }
            base.OnAuthorization(filterContext);
        }
    }
}