using Bug_Management_App.Data;
using Bug_Management_App.Dtos;
using Bug_Management_App.Interfaces;
using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug_Management_App.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterUsers _registerUsers;
        private readonly IEncrypter _encrypter;

        public RegisterController(IRegisterUsers registerUsers, IEncrypter encrypter)
        {
            _registerUsers = registerUsers;
            _encrypter = encrypter;
            
        }

        public RegisterController()
        {

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterUserDto user)
        {

            if (ModelState.IsValid)
            {
                user.Password = _encrypter.EncryptPassword(user.Password);
                var mappedRegisterModel = AutoMap._mapper.Map<Users>(user);

                _registerUsers.RegisterUser(mappedRegisterModel);

                _registerUsers.SaveChanges();

                return RedirectToAction("Login", "Login");

            }

            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
    }
}