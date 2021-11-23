﻿using Bug_Management_App.Controllers;
using Bug_Management_App.Dtos;
using Bug_Management_App.Interfaces;
using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Repos
{
    public class SqlUsersRepo : IRegisterUsers, IUsers, IProjects, IRoles, IBugs
    {
        private readonly Entities _DB;

        public SqlUsersRepo()
        {
            _DB = new Entities();
            
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
        public void SaveChanges()
        {
            _DB.SaveChanges();
        }

        public void CreateBug(Bugs bug)
        {
            _DB.Bugs.Add(bug);
        }

        public Bugs ExistingBugReport(int bugId)
        {
            return _DB.Bugs.FirstOrDefault(b => b.BugId == bugId);
        }

        public IEnumerable<Bugs> GetBugsPerProject(int projectId)
        {
            string query = "SELECT * FROM Bugs WHERE ProjectId = @p0";
            return _DB.Bugs.SqlQuery(query, projectId).DefaultIfEmpty();
        }

        public IEnumerable<UsersListForTeamsDto> GetUsersListForTeams()
        {
            return _DB.Users.Select(u => new UsersListForTeamsDto { Id = u.Id, Name = u.Name, LastName = u.LastName, Role = u.Role});
        }

        public void SetUserToProject(UsersProjects userProject)
        {
            _DB.UsersProjects.Add(userProject);
        }
    }
}