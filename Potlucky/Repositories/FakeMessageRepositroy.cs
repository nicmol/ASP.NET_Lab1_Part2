using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Potlucky.Models;

namespace Potlucky.Repositories
{
    public class FakeMessageRepository : IMessageRepository

    {
        public FakeMessageRepository()
        {
            User cora = new User
            {
                FirstName = "Cora",
                LastName = "Molitor",
                Email = "cm@test.com",
                ImageUrl = "/images/stuffing.jpg"
            };
            Message message1 = new Message
            {
                Sender = cora,
                MessageText = "Hello, let's plan Thanksgiving!",
                Date = DateTime.Parse("8/30/19")

            };
         
            Message message2 = new Message
            {
                Sender = cora,
                MessageText = "Can anyone bring a salad?",
                Date = DateTime.Parse("9/10/19")

            };

            Message message3 = new Message
            {
                Sender = cora,
                MessageText = "Can anyone bring wine?",
                Date = DateTime.Parse("10/20/19")

            };
            messages = new List<Message>();
            AddMessage(message1);
            AddMessage(message2);
            AddMessage(message3);
        }
        private static List<Message> messages; //= new List<Message>();
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

        public void AddReplyToMessage(string firstName, string lastName, string email, string messageText, int messageId)
        {
            throw new NotImplementedException();
        }

        public Message getMessageById(int messageId)
        {
            throw new NotImplementedException();
        }
    }
}
