using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Management_App.Data
{
    public class SqlRepoUsers: IRegisterUser
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlRepoUsers(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void RegisterUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
        }
    }
}
