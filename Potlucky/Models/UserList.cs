using System;
using System.Collections.Generic;


namespace Potlucky.Models
{
    public static class UserList
    {
        private static List<User> users = new List<User>();
        public static List<User> Users { get { return users; } }
        public static void AddUser(User user)
        {
            users.Add(user);
        }

    }
}
