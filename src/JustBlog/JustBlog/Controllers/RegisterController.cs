using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBlog.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/

        public ActionResult Post()
        {
            return View();
        }

        public ViewResult LogOn()
        {
            return View();
        }

        public ViewResult Register()
        {
            return View();
        }

        /// <summary>
        /// The function above is used for Login process
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        //Register Form Process
        [HttpPost, ValidateInput(false)]
        public ActionResult Register(RegisterController model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
