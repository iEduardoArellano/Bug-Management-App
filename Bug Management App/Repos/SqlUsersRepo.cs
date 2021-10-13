using Bug_Management_App.Controllers;
using Bug_Management_App.Dtos;
using Bug_Management_App.Interfaces;
using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Repos
{
    public class SqlUsersRepo : IRegisterUsers, IUsers, IProjects
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

        public IEnumerable<Projects> GetProjectsInDb()
        {
            return _projects.Projects.ToList();
        }

        public Users GetUserAtLogin(LoginUserDto loginUser)
        {
            
            return _users.Users.FirstOrDefault(u => u.UserName == loginUser.UserName && u.Password == loginUser.Password);
        }

        public void CreateProject(Projects projectToCreate)
        {
            _projects.Projects.Add(projectToCreate);

            _projects.SaveChanges();
        }
    }
}