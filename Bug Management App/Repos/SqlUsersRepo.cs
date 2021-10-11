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
        private readonly UsersTable _UsersTbl;
        private readonly ProjectsTable _ProjectsTbl;

        public SqlUsersRepo()
        {
            _UsersTbl = new UsersTable();
            _ProjectsTbl = new ProjectsTable();
        }

        public Users GetUserByUserName(string userName)
        {
            
            return _UsersTbl.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public IEnumerable<Projects> GetProjects()
        {
            return _ProjectsTbl.Projects.ToList();
        }
        public void RegisterUser(Users user)
        {
            _UsersTbl.Users.Add(user);

            _UsersTbl.SaveChanges();
        }
    }
}