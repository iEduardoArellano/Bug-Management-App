using AutoMapper;
using Bug_Management_App.Data;
using Bug_Management_App.Dtos;
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

        public RegisterController(IRegisterUsers registerUsers)
        {
            _registerUsers = registerUsers;
            
        }

        public RegisterController()
        {

        }

        [HttpPost]
        public ActionResult Register(RegisterUserDto user)
        {

            if (ModelState.IsValid)
            {
                var mappedRegisterModel = AutoMap._mapper.Map<Users>(user);

                _registerUsers.RegisterUser(mappedRegisterModel);

                return View();

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