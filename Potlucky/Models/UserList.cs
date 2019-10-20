using System;
using System.Collections.Generic;


namespace Potlucky.Models
{
    public static class UserList
    {
        static UserList()
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
        public static List<User> Users { get { return users; } }
        public static void AddUser(User user)
        {
            users.Add(user);
        }

        public static User getUserByFirstName(string firstName)
        {

            User user = users.Find(u => u.FirstName == firstName);
            return user;
        }

    }
}

