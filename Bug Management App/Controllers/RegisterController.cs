using AutoMapper;
using Bug_Management_App.Data;
using Bug_Management_App.Dtos;
using Bug_Management_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Management_App.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        private readonly IRegisterUser _registerUser;

        public RegisterController(IMapper mapper, IEncrypter encrypter, IRegisterUser registerUser)
        {
            _mapper = mapper;
            _encrypter = encrypter;
            _registerUser = registerUser;
        }

        [HttpPost]
        public IActionResult Register(RegisterUserDto registerUser)
        {
            if (ModelState.IsValid)
            {
                registerUser.Password = _encrypter.EncryptPassword(registerUser.Password);
                var mappedUser = _mapper.Map<User>(registerUser);

                _registerUser.RegisterUser(mappedUser);

                return View();

            }

            return View("Privacy");

        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
