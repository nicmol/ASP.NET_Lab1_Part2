using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Potlucky.Models;

namespace Potlucky.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;
        public List<User> Users { get { return _context.Users.ToList(); } }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User getUserByFirstName(string firstName)
        {
            User user = _context.Users.FirstOrDefault(u => u.FirstName == firstName);
            return user;
        }

    }
}

