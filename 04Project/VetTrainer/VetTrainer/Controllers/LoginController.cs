using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using VetTrainer.Models;
using System.Web.Security;
using System.Security.Principal;

namespace VetTrainer.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Login")]
    public class LoginController : Controller
    {
        //private ApplicationSignInManager _signInManager;
        //private VetAppUserManager _userManager;

        private VetAppDBContext _context;

        public LoginController()
        {
            _context = new VetAppDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("~/")]
        [HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                // First we clean the authentication ticket like always;
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();
            }
            return View();
        }

        // POST: Login
        [Route("~/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {

            }
            catch (HttpAntiForgeryException ex)
            {
                Console.WriteLine($"AntiForgeryException: {ex.Message}.");
                ModelState.AddModelError("", "AntiFogery Token不匹配，请检查！");
                return View(user);
            }

            if (!ModelState.IsValid)
                return View(user);

            if (Authentication.UserManager.ValidateUser(user, Response))
            {
                // SetSession
                //HttpContext.Session["_Role"] = user.Authority.ToString();

                //Claim[] claims = LoadClaimsForUser(user);
                //var id = new ClaimsIdentity(claims, "Forms");
                //var cp = new ClaimsPrincipal(id);

                //var token = new SessionSecurityToken(cp);
                //var sam = FederatedAuthentication.SessionAuthenticationModule;
                //sam.WriteSessionTokenToCookie(token);
                //Session["UserID"] = $"{user.Id}_{Guid.NewGuid().ToString() }";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Fail to sign in
                ModelState.AddModelError(Views.Strings.Keys.LoginErrValidation, Views.Strings.Login.LoginErrValidationValue);
                return View(user);
            }

        }

        private Claim[] LoadClaimsForUser(User user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role, user.Authority.ToString()),
                new Claim("https://vetAppLearning.com/claims/UserAuthority",user.Authority.ToString()),
            };
            return claims;
        }

        // GET: EnsureLoggedOut
        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

        // GET: Logout
        //[HttpPost]
        public ActionResult Logout()
        {
            try
            {
                //// First we clean the authentication ticket like always
                ////required NameSpace: using System.Web.Security;

                //FormsAuthentication.SignOut();

                //// Second we clear the principal to ensure the user does not retain any authentication
                ////required NameSpace: using System.Security.Principal;
                //HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                //Session.Clear();
                //System.Web.HttpContext.Current.Session.RemoveAll();

                //// Third we clear authentication cookie.
                //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                //cookie.Expires = DateTime.Now.AddYears(-1);
                //Response.Cookies.Add(cookie);

                Authentication.UserManager.Logout(Session, Response, HttpContext);

                // After all these we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request
                return RedirectToAction("Login", "Login");
            }
            catch
            {
                throw;
            }
        }



        //GET: SignInAsync
        private void SetIsToRemember(string userName, bool isPersistent = false)
        {
            // Clear any lingering authencation data
            FormsAuthentication.SignOut();

            // Write the authentication cookie
            FormsAuthentication.SetAuthCookie(userName, isPersistent);
        }

        //GET: RedirectToLocal
        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site
                // so we will redirect to this "action"
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                    return Redirect(returnURL);

                // If we cannot verify if the url is local to our host we redirect to a default location
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                throw;
            }
        }
    }
}