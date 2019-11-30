using Potlucky.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Potlucky.Models
{
    public class MessageList : IMessageRepository
    {
        private static List<Message> messages = new List<Message>();
        public List<Message> Messages { get { return messages; } }
        public void AddMessage(Message message)
        {
            messages.Add(message);
        }
 
        public Message getMessageByDate(DateTime date)
        {

            Message message = messages.Find(m => m.Date.ToString() == date.ToString());
            return message;
        }

        public IEnumerable<Message> GetMessages()
        {
            throw new NotImplementedException();
        }
    }

}
