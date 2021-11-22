using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Dtos
{
    public class UpdateBugDto
    {
        public int BugId { get; set; }

        [Display(Name ="Titulo")]
        public string Title { get; set; }

        [Display(Name ="Descripción")]
        public string Description { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Image { get; set; }

        [Display(Name = "Sistema Operativo")]
        public string OperatingSystem { get; set; }

        [Display(Name = "Versión SO")]
        public string OSVersion { get; set; }

        [Display(Name = "Verisión App")]
        public string AppVersion { get; set; }

        [Display(Name = "Estado")]
        public string Status { get; set; }

        
        public System.DateTime LastUpdateDate { get; set; }

        
        public int AsignedToUser { get; set; }

        
        public int ProjectId { get; set; }

        [Display(Name = "Link video")]
        public string VideoLink { get; set; }
    }
}