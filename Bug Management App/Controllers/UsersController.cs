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
        private IRoles _roles;

        public UsersController(IUsers users, IRoles roles)
        {
            _users = users;
            _roles = roles;
        }

       public ActionResult Index(string userId)
        {
            var user = _users.GetUserByUserName(userId);
            var roles = _roles.GetRoles();
            if (user.Role == null)
            {
                ViewBag.roles = roles;
                return View(user);
            }

            return RedirectToAction("Index", "Projects");
        }
        

    }
}