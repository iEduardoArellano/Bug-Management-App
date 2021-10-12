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
        private readonly UsersTbl _users;
        private readonly ProjectsTbl _projects;

        public SqlUsersRepo()
        {
            _users = new UsersTbl();
            _projects = new ProjectsTbl();
        }

        public Users GetUserByUserName(string userName)
        {
            return _users.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public void RegisterUser(Users user)
        {
            _users.Users.Add(user);

            _users.SaveChanges();
        }
    }
}