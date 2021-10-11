using Bug_Management_App.Controllers;
using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Repos
{
    public class SqlUsersRepo : IRegisterUsers
    {
        private readonly UsersDBEntities _usersDB;

        public SqlUsersRepo()
        {
            _usersDB = new UsersDBEntities();
        }

        public void RegisterUser(Users user)
        {
            _usersDB.Users.Add(user);

            _usersDB.SaveChanges();
        }
    }
}