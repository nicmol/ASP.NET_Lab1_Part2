using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Potlucky.Models;

namespace Potlucky.Repositories
{
    public interface IUserRepository
    {
        List<User> Users { get; }
        void AddUser(User user);

        User getUserByFirstName(string firstName);
    }
}
