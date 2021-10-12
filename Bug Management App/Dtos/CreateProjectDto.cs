using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Dtos
{
    public class CreateProjectDto
    {
        public string CompanyName { get; set; }
        public byte[] Logo { get; set; }
        public string ProjectManager { get; set; }
        public string Status { get; set; }
    }
}