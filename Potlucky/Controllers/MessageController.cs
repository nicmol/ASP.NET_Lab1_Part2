using Microsoft.AspNetCore.Mvc;
using Potlucky.Models;
using System.Collections.Generic;
using System;
using System.Linq;





namespace Potlucky.Controllers
{
    public class MessageController : Controller
    {
        

        public IActionResult Index()
        {
            List<Message> messages = MessageList.Messages;

            messages.Sort((m1, m2) => m1.Date.CompareTo(m2.Date));

            return View(messages);
        }

        public IActionResult AddMessage()
        {

            return View();
        }

        public IActionResult AddReply()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddMessage(string firstName, string lastName, string email, string messageText, string date, string subject)
        {
            User user = new User();
            Message message = new Message();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            message.MessageText = messageText;
            message.Sender = user;
            message.Date = DateTime.Parse(date);
            message.Subject = subject;
            MessageList.AddMessage(message);

            return RedirectToAction("Index");


        }

        [HttpPost]
        public RedirectToActionResult AddReply(string firstName, string lastName, string email, 
            string messageText, string date, string subject)
        {
            Message message = MessageList.getMessageBySubject(subject);
            User user = new User();
            Reply reply = new Reply();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            reply.MessageText = messageText;
            reply.Sender = user;
            reply.Date = DateTime.Parse(date);

            message.Replies.Add(reply);

            return RedirectToAction("Index");


        }
    }


}
