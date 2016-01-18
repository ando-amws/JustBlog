using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustBlog.Models;
using JustBlog.Core;
using JustBlog.Core.Objects;
using System.Web.Security;
using JustBlog.Providers;

namespace JustBlog.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public LoginController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        public ActionResult Post()
        {
            return View();
        }
        public ViewResult LogOn()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        [Authorize]
        public ActionResult LogOn(User model, string returnUrl)
        {
            UserModel um = new UserModel(model);
            if (ModelState.IsValid)
            {
                // Verify if user loggin is true
                if (_authProvider.Login(model))
                {
                    //FormsAuthentication.RedirectFromLoginPage("", false);
                    return RedirectToUrl(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Incorrect");
                }
            }
            return View(model);
        }

        private ActionResult RedirectToUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Blog");
            }
        }



    }
}
