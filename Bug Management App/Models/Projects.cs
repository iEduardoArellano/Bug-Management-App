//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bug_Management_App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Projects
    {
        public int ProjectId { get; set; }
        public string CompanyName { get; set; }
        public byte[] Logo { get; set; }
        public string ProjectManager { get; set; }
        public string Status { get; set; }
        public string ProjectName { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int Creator { get; set; }
    }
}
