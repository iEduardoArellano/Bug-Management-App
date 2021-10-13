using System.ComponentModel.DataAnnotations;

namespace Bug_Management_App.Dtos
{
    public class LoginUserDto
    {

        [Required]
        [Display(Name ="Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}