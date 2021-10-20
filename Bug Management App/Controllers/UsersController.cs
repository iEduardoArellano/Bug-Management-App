using Bug_Management_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug_Management_App.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private IUsers _users;

        public UsersController(IUsers users)
        {
            _users = users;
        }

       public ActionResult Index(int userId)
        {
            var user = _users.GetUserById(userId);
            if (user.Role == null)
            {
                return View(user);
            }

            return RedirectToAction("Index", "Projects");
        }


    }
}