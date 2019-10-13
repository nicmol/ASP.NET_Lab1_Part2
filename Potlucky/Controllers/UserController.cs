using Microsoft.AspNetCore.Mvc;
using Potlucky.Models;
using System.Collections.Generic;

namespace Potlucky.Controllers
{
    public class UserController: Controller
    {
        //Testin add user
        User user;
        public UserController()
        {
           if(UserList.Users.Count == 0)
            {
                user = new User()
                {
                    FirstName = "Nicolette",
                    LastName = "Molitor",
                    Email = "molitorn@my.lanecc.edu"
                };
                UserList.AddUser(user);
            }
        }



        public IActionResult Index()
        {
            List<User> users = UserList.Users;
            return View(users);
        }



        public IActionResult AddUser()
        {
            
            return View();
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
