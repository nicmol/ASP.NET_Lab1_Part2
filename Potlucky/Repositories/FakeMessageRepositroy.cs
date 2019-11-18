using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potlucky.Repositories
{
    public class FakeMessageRepositroy : IMessageRepository
    {
        private static List<Message> messages = new List<Message>();
        public static List<Message> Messages { get { return messages; } }
        public static void AddMessage(Message message)
        {
            messages.Add(message);
        }

        public static Message getMessageByDate(DateTime date)
        {

            Message message = messages.Find(m => m.Date.ToString() == date.ToString());
            return message;
        }
    }
}
