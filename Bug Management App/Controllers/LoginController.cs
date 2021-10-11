using Bug_Management_App.Dtos;
using Bug_Management_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Bug_Management_App.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsers _users;

        public LoginController(IUsers users)
        {
            _users = users;
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserDto loginUser)
        {
            if (ModelState.IsValid)
            {
                var userInDB = _users.GetUserByUserName(loginUser.UserName);
                if (userInDB != null)
                {
                    FormsAuthentication.SetAuthCookie(loginUser.UserName, true);
                    return RedirectToAction("Index", "Projects");
                }

            }
            return RedirectToAction("Index", "Projects");
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
    }
}