using System.ComponentModel.DataAnnotations;

namespace Bug_Management_App.Controllers
{
    public class LoginUserDto
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}