using Bug_Management_App.Dtos;
using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Management_App.Interfaces
{
    public interface IUsers
    {
        Users GetUserByUserName(string userName);

        Users GetUserAtLogin(LoginUserDto loginUser);

        Users GetUserById(int userId);

        bool UserExists(string userName);

        void SaveChanges();
    }
}
