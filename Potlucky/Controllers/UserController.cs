using Microsoft.AspNetCore.Mvc;
using Potlucky.Models;
using System.Collections.Generic;

namespace Potlucky.Controllers
{
    public class UserController: Controller
    {
        
        User user;

        public IActionResult Index()
        {
            List<User> users = UserList.Users;
            return View(users);
        }



        public IActionResult AddUser()
        {
            
            return View();
        }

        public IActionResult UserDetail(string firstName)
        {

            
            User user = UserList.getUserByFirstName(firstName);
            if (firstName == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        public RedirectToActionResult AddUser(string firstName, string lastName, string email)
        {
            user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;

            UserList.AddUser(user);

            return RedirectToAction("Index");


        }

    }
}
