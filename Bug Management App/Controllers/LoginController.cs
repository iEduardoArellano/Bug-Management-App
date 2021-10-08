using Bug_Management_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                    Session["Id"] = userInDB.Id.ToString();
                    Session["UserName"] = userInDB.UserName.ToString();
                    return View("Iniciaste Sesion");
                }

            }
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
    }
}