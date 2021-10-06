using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Management_App.Data
{
    public interface IRegisterUser
    {
        void RegisterUser(User user);
    }
}
