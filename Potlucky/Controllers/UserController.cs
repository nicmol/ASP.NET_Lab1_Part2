using Microsoft.AspNetCore.Mvc;
using Potlucky.Models;
using System.Collections.Generic;
using System;

namespace Potlucky.Controllers
{
    public class UserController: Controller
    {
        
        User user;

        public IActionResult Index()
        {
            List<User> users = UserList.Users;
            users.Sort((u1, u2) => string.Compare(u1.LastName, u2.LastName, StringComparison.Ordinal));

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
            ViewBag.name = user.FirstName + " " + user.LastName;

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
