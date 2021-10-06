using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Management_App.Controllers
{
    public class LoginController : ControllerBase
    {
        public LoginController()
        {

        }

        [HttpPost]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
