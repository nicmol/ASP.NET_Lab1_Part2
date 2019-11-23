using Microsoft.AspNetCore.Mvc;
using Potlucky.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Potlucky.Repositories;

namespace Potlucky.Controllers
{
    public class MessageController : Controller
    {
        IMessageRepository repo; //= new FakeMessageRepository();
        public MessageController(IMessageRepository r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
            List<Message> messages = repo.Messages;

            messages.Sort((m1, m2) => m2.Date.CompareTo(m1.Date));

            foreach(Message message in messages)
            {
                message.Replies.Sort((r1, r2) => r2.Date.CompareTo(r1.Date));
            }
            return View(messages);


        }

        public IActionResult AddMessage()
        {

            return View();
        }

        public IActionResult AddReply(string messageDate)
        {
            Message message = repo.getMessageByDate(DateTime.Parse(messageDate));
            User user = message.Sender;
            ViewBag.name = user.FirstName;
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddMessage(string firstName, string lastName, string email, string messageText)
        {
            User user = new User();
            Message message = new Message();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            message.MessageText = messageText;
            message.Sender = user;
            message.Date = DateTime.Now;
            repo.AddMessage(message);

            return RedirectToAction("Index");


        }

        [HttpPost]
        public RedirectToActionResult AddReply(string firstName, string lastName, string email, 
            string messageText, string messageDate)
        {
            Message message = repo.getMessageByDate(DateTime.Parse(messageDate));
            User user = new User();
            Reply reply = new Reply();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            reply.MessageText = messageText;
            reply.Sender = user;
            reply.Date = DateTime.Now;

            message.Replies.Add(reply);

            return RedirectToAction("Index");


        }
    }


}
