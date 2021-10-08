﻿using Bug_Management_App.Controllers;
using Bug_Management_App.Interfaces;
using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Repos
{
    public class SqlUsersRepo : IRegisterUsers, IUsers
    {
        private readonly UsersDB _usersDB;

        public SqlUsersRepo()
        {
            _usersDB = new UsersDB();
        }

        public Users GetUserByUserName(string userName)
        {
            return _usersDB.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public void RegisterUser(Users user)
        {
            _usersDB.Users.Add(user);

            _usersDB.SaveChanges();
        }
    }
}