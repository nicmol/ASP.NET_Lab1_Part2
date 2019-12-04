using Potlucky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Potlucky.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        private readonly ApplicationDbContext _context;

        public List<Message> Messages { get {
                return _context.Messages.Include("Sender").Include("Replies.Sender").ToList();
            }
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void AddReplyToMessage(string firstName, string lastName, string email,
            string messageText, int messageId)
        {
           
            User user = new User();
            Reply reply = new Reply();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            reply.MessageText = messageText;
            reply.Sender = user;
            reply.Date = DateTime.Now;

            _context.Messages.Find(messageId).Replies.Add(reply);
            
            _context.SaveChanges();
        }

        public Message getMessageByDate(DateTime date)
        {
            Message message = Messages.FirstOrDefault(m => m.Date.ToString() == date.ToString());
            return message;
        }

        public Message getMessageById(int messageId)
        {
            Message message = Messages.Find(m => m.MessageId == messageId);
            return message;
        }

        public void AddReplyToMessage(string firstName, string lastName, string email, string messageText, string messageDate)
        {
            throw new NotImplementedException();
        }


       
    }
}
