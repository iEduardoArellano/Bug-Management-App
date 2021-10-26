using Bug_Management_App.Interfaces;
using Bug_Management_App.Models;
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
        private readonly IUsers _users;
        private readonly IRoles _roles;

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

        public ActionResult SetRole(Users edited)
        {
            var user = _users.GetUserByUserName(User.Identity.Name);

            user.Role = edited.Role;

            _users.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }
        

    }
}