using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Potlucky.Models;

namespace Potlucky.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
      public FakeUserRepository()
        {
            User nicolette = new User
            {
                FirstName = "Nicolette",
                LastName = "Molitor",
                Email = "molitorn@my.lanecc.edu",
                ImageUrl = "/images/rawturkey.jpg"
            };
            User dylan = new User
            {
                FirstName = "Dylan",
                LastName = "Bragg",
                Email = "db@test.com",
                ImageUrl = "/images/hotdog.jpg"
            };
            User cora = new User
            {
                FirstName = "Cora",
                LastName = "Molitor",
                Email = "cm@test.com",
                ImageUrl = "/images/stuffing.jpg"
            };

            AddUser(nicolette);
            AddUser(dylan);
            AddUser(cora);

        }

        private static List<User> users = new List<User>();
        public List<User> Users { get { return users; } }
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User getUserByFirstName(string firstName)
        {

            User user = users.Find(u => u.FirstName == firstName);
            return user;
        }

    }
}

