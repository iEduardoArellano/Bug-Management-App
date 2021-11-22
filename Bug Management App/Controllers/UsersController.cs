using Bug_Management_App.Dtos;
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

            ViewBag.roles = roles.Select(x => new SelectListItem
            {
                Text = x.Role,
                Value = x.Id.ToString()
            });
            return View(user);
        }
        public ActionResult SetRole(RegisterUserDto registerUserDto )
        {
            var user = _users.GetUserByUserName(User.Identity.Name);

            user.Role = registerUserDto.Role;
            _users.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }

    }
}