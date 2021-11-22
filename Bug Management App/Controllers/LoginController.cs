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
        private readonly IEncrypter _encrypter;

        public LoginController(IUsers users, IEncrypter encrypter)
        {
            _users = users;
            _encrypter = encrypter;
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserDto loginUser)
        {
            if (ModelState.IsValid)
            {
                loginUser.Password = _encrypter.EncryptPassword(loginUser.Password);
                var userInDB = _users.GetUserAtLogin(loginUser);
                if (userInDB != null)
                {
                    FormsAuthentication.SetAuthCookie(loginUser.UserName, true);
                    if (userInDB.Role == 0)
                    {
                        return RedirectToAction("Index", "Users", new { userId = userInDB.UserName });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Projects");
                    }
                    
                }

            }
            return RedirectToAction("Login", "Login");
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