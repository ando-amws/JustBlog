
using System.Web;
using System.Web.Security;
using JustBlog.Core;
using JustBlog.Core.Objects;
using System;

namespace JustBlog.Providers
{
  public class AuthProvider: IAuthProvider
  {
        private readonly IUserRepository _userRepository;

        public AuthProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Return True if the user is already logged-in.
        /// </summary>
        public bool IsLoggedIn()
        {
            string session = (string)HttpContext.Current.Session["Session"];

            // Just Verify session variable
            if(session != null)
            { 
              return true;
            }
            return false;
        }

        /// <summary>
        /// Authenticate an user and set cookie if user is valid.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(User user)
        {
            // Return true if user exist
            var result = _userRepository.IsAdminExist(user.Username, user.Password);

            // Return all fields on sgbd user if username matches
            var userdata = _userRepository.getUser(user.Username);

            // If user doesn't exist, verify that he fill correctly the form
            if (result)
            {
                //FormsAuthentication.SetAuthCookie(username, false);
                HttpCookie usernameCookie = new HttpCookie("Username");
                HttpCookie pwdCookie = new HttpCookie("Password");
                HttpCookie sessionCookie = new HttpCookie("Session");

                // set Expiration date
                usernameCookie.Expires = DateTime.Now.AddDays(1d);
                pwdCookie.Expires = DateTime.Now.AddDays(1d);
                sessionCookie.Expires = DateTime.Now.AddDays(1d);

                // Set Value on cookies
                usernameCookie.Value = userdata.Username;
                pwdCookie.Value = userdata.Password;
                sessionCookie.Value = Convert.ToString(userdata.Session);

            }

          return result;
        }

        /// <summary>
        /// Logout the user.
        /// </summary>
        public void Logout()
        {
            //FormsAuthentication.SignOut();
            HttpCookie usernameCookie = new HttpCookie("Username");
            HttpCookie pwdCookie = new HttpCookie("Password");
            HttpCookie sessionCookie = new HttpCookie("Session");

            // set Expiration date
            usernameCookie.Expires = DateTime.Now.AddDays(1d);
            pwdCookie.Expires = DateTime.Now.AddDays(1d);
            sessionCookie.Expires = DateTime.Now.AddDays(1d);

            // Assign a null value
            usernameCookie.Value = null;
            pwdCookie.Value = null;
            sessionCookie.Value = null;

            // Destroy session
            HttpContext.Current.Session.Remove("Username");
            HttpContext.Current.Session.Remove("Password");
            HttpContext.Current.Session.Remove("Session");
            HttpContext.Current.Session.RemoveAll();

        }
  }

}