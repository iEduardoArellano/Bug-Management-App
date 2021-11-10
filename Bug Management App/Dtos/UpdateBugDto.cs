using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Dtos
{
    public class UpdateBugDto
    {
        public int BugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string OperatingSystem { get; set; }
        public string OSVersion { get; set; }
        public string AppVersion { get; set; }
        public string Status { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public int AsignedToUser { get; set; }
        public int ProjectId { get; set; }
        public string VideoLink { get; set; }
    }
}