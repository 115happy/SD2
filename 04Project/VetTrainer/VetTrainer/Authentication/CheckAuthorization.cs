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
    public class CheckAuthorizationAttribute : AuthorizeAttribute
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
                string userData = ((FormsIdentity)(filterContext.HttpContext.User.Identity)).Ticket.UserData;

                // Deserialize the json data and set it on the custom principal.
                var serializer = new JavaScriptSerializer();
                principal.User = (UserDto)serializer.Deserialize(userData, typeof(UserDto));

                // Set the context user as the authPrincipal hence views can retrive user data.
                filterContext.HttpContext.User = principal;

                // Page level authentication
            }
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Redirect to login page.
            filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "action", "Login" },
                        { "controller", "Login" }
                    });
        }

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    var id = HttpContext.Current.User.Identity as FormsIdentity;
        //    if (id != null && id.IsAuthenticated)
        //    {
        //        var roles = id.Ticket.UserData.Split(',');
        //        HttpContext.Current.User = new GenericPrincipal(id, roles);
        //    }
        //}

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    if (HttpContext.Current.Session["UserID"] == null || !HttpContext.Current.Request.IsAuthenticated)
        //    {
        //        if (filterContext.HttpContext.Request.IsAjaxRequest())
        //        {
        //            filterContext.HttpContext.Response.StatusCode = 302; //Found Redirection to another page. Here- login page. Check Layout ajaxError() script.
        //            filterContext.HttpContext.Response.End();
        //        }
        //        else
        //        {
        //            filterContext.Result = new RedirectToRouteResult(
        //                new RouteValueDictionary
        //                {
        //                    { "action", "Login" },
        //                    { "controller", "Login" }
        //                });
        //        }
        //    }
        //    else
        //    {

        //        //Code HERE for page level authorization

        //    }
        //}
    }


}