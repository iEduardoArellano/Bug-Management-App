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
    
    public partial class Bugs
    {
        public int BugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string OperatingSystem { get; set; }
        public string OSVersion { get; set; }
        public string AppVersion { get; set; }
        public string Status { get; set; }
        public System.DateTime CreationDate { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public int ReportedByUser { get; set; }
        public int AsignedToUser { get; set; }
        public int ProjectId { get; set; }
    }
}
