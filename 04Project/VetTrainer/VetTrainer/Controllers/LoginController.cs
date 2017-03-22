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

            if (IsValid(user.Name, user.Password))
            {
                // Successfully signed in
                //FormsAuthentication.SetAuthCookie(user.Name, user.IsToRememberMe);
                SetIsToRemember(user.Name, user.IsToRememberMe);
                Session["UserID"] = $"{user.Id}_{Guid.NewGuid().ToString() }";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Fail to sign in
                ModelState.AddModelError(Views.Strings.ModelErrorKeys.LoginErrValidation, Views.Strings.Login.ErrValidationSummary);
                //TempData["ErrorMsg"] = "Access Denied! Wrong Credential.";
                return View(user);
            }

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
                // First we clean the authentication ticket like always
                //required NameSpace: using System.Web.Security;
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication
                //required NameSpace: using System.Security.Principal;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request
                return RedirectToAction("Login", "Login");
                //return RedirectToLocal();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Checks if user with given password exists in the database.
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password">User password</param>
        /// <returns></returns>
        public static bool IsValid(string username, string password)
        {
            using (VetAppDBContext context = new VetAppDBContext())
            {

                // var clinics = context.Clinics.Include(c=>c.Instruments).ToList();
                var users = context.Users.ToList();
                string encryptedPassword = Utilities.Encoder.Encode(password);
                User foundUser = users.SingleOrDefault(u =>
                    u.Name == username && u.Password == encryptedPassword);
                if (foundUser != null) return true;
                return false;
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