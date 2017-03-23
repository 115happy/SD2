using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Authentication
{
    public static class UserManager
    {
        /// <summary>
        /// Returns the User from the Context.User.Identity by decrypting the forms auth ticket and returning the user object.
        /// </summary>
        public static UserDto User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // The user is authenticated. Return the user from the forms auth ticket.
                    AuthPrincipal authPrincipal = HttpContext.Current.User as AuthPrincipal;
                    return authPrincipal.User;
                }
                else if (HttpContext.Current.Items.Contains(Views.Strings.Keys.AuthUserTempData))
                {
                    // The user is not authenticated, but has successfully logged in.
                    return (UserDto)HttpContext.Current.Items[Views.Strings.Keys.AuthUserTempData];
                }
                else
                {
                    return null;
                }
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
                if (foundUser != null)
                {
                    // Store the user as userDto temporarily in the context for this request.
                    var userDto = Mapper.Map<User, UserDto>(foundUser);
                    HttpContext.Current.Items.Add(Views.Strings.Keys.AuthUserTempData, userDto);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Authenticates a user and creates the associated forms authentication ticket.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="response"></param>
        /// <returns>If the user is valid</returns>
        public static bool ValidateUser(User user, HttpResponseBase response)
        {
            bool result = false;

            if (IsValid(user.Name, user.Password))
            {
                // Successfully signed in
                FormsAuthentication.SignOut();

                // Serialize the userDto obj to be deserialized on authentication
                var serializer = new JavaScriptSerializer();
                string userData = serializer.Serialize(User);

                // Write cookie
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    version: 1,
                    name: user.Name,
                    issueDate: DateTime.Now,
                    expiration: DateTime.Now.Add(FormsAuthentication.Timeout),
                    isPersistent: user.IsToRememberMe,
                    userData: userData,
                    cookiePath: FormsAuthentication.FormsCookiePath);

                HttpCookie cookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(ticket));
                response.Cookies.Add(cookie);

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Clears the user session, clears the forms auth ticket, expires the forms auth cookie.
        /// </summary>
        /// <param name="session">HttpSessionStateBase</param>
        /// <param name="response">HttpResponseBase</param>
        public static void Logout(HttpSessionStateBase session, HttpResponseBase response, HttpContextBase context)
        {
            // First clean the authentication ticket like always

            FormsAuthentication.SignOut();

            // Second we clear the principal to ensure the user does not retain any authentication
            context.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            session.Clear();
            HttpContext.Current.Session.RemoveAll();

            //// Last we clear authentication cookie.
            //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, string.Empty);
            //cookie.Expires = DateTime.Now.AddYears(-1);
            //response.Cookies.Add(cookie);
        }
    }
}