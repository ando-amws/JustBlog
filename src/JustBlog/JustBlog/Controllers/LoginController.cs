using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustBlog.Models;
using JustBlog.Core;
using JustBlog.Core.Objects;
using System.Web.Security;

namespace JustBlog.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
        public ActionResult LogOn(User model)
        {
            UserModel um = new UserModel(model);
            if (ModelState.IsValid)
            {
                if (um.IsUserExist(_userRepository, model))
                {
                    FormsAuthentication.RedirectFromLoginPage("", false);
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Incorrect");
                }
            }
            return View(model);
        }

    }
}
