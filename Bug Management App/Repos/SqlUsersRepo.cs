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
    public class SqlUsersRepo : IRegisterUsers, IUsers, IProjects, IRoles
    {
        private readonly UsersDBEntities _DB;

        public SqlUsersRepo()
        {
            _DB = new UsersDBEntities();
            
        }

        public Users GetUserByUserName(string userName)
        {
            return _DB.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public Users GetUserById(int userId)
        {
            return _DB.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void RegisterUser(Users user)
        {
            _DB.Users.Add(user);
        }

        public IEnumerable<Projects> GetProjectsInDb()
        {
            return _DB.Projects.ToList();
        }

        public IEnumerable<Projects> GetProjectsCreatedByUser(int userId)
        {
            string query = "SELECT * FROM Projects WHERE Creator = @p0";
            return _DB.Projects.SqlQuery(query, userId).DefaultIfEmpty();
        }

        public Users GetUserAtLogin(LoginUserDto loginUser)
        {
            
            return _DB.Users.FirstOrDefault(u => u.UserName == loginUser.UserName && u.Password == loginUser.Password);
        }


        public void CreateProject(Projects projectToCreate)
        {
            _DB.Projects.Add(projectToCreate);

            
        }

        public Projects GetProjectById(int projectId)
        {
            return _DB.Projects.FirstOrDefault(p => p.ProjectId == projectId);
        }

        public void DeleteProject(int projectId)
        {
            var projectToDelete = GetProjectById(projectId);
            _DB.Projects.Remove(projectToDelete);
        }


        public void SaveChanges()
        {
            _DB.SaveChanges();
        }

        public void SaveProjectsChanges()
        {
            _DB.SaveChanges();
        }

        public bool UserExists(string userName)
        {
            if (_DB.Users.FirstOrDefault(u => u.UserName == userName) != null)
            {
                return true;
            }

            return false;
           
        }

        public List<Roles> GetRoles()
        {
            return _DB.Roles.ToList();
        }
    }
}