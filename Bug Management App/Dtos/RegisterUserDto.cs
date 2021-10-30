using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [Display(Name ="Nombres")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Apellidos")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Correo")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Rol")]
        public int Role { get; set; }
    }
}