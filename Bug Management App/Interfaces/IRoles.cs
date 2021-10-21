using Bug_Management_App.Models;
using System.Collections.Generic;

namespace Bug_Management_App.Interfaces
{
    public interface IRoles
    {
        IEnumerable<Roles> GetRoles();
    }
}