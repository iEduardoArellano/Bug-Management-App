using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Dtos
{
    public class UsersListForTeamsDto
    {
        public int Id { get; set; }

        [Display(Name = "Nombres")]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Display(Name = "Rol")]
        public string Role { get; set; }
    }
}