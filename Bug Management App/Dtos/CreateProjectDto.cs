using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Dtos
{
    public class CreateProjectDto
    {
        [Required]
        [Display(Name ="Nombre del proyecto")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name ="Compañia")]
        public string CompanyName { get; set; }
 
        public byte[] Logo { get; set; }

        [Required]
        public string ProjectManager { get; set; }
     
        public string Status { get; set; }

        public System.DateTime CreationDate { get; set; }
        public int Creator { get; set; }
    }
}