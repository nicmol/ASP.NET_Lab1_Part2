using Microsoft.AspNetCore.Mvc;
using Potlucky.Models;
using System.Collections.Generic;
using System;





namespace Potlucky.Controllers
{
    public class MessageController : Controller
    {
        Message message;

        public IActionResult Index()
        {
            List<Message> messages = MessageList.Messages;
            return View(messages);
        }

        public IActionResult AddMessage()
        {

            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddMessage(string firstName, string lastName, string email, string messageText, string date)
        {
            User user = new User();
            message = new Message();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            message.MessageText = messageText;
            message.Sender = user;
            message.Date = DateTime.Parse(date);

            MessageList.AddMessage(message);

            return RedirectToAction("Index");


        }
    }


}
