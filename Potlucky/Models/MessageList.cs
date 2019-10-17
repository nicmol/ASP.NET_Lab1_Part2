using System;
using System.Collections.Generic;

namespace Potlucky.Models
{
    public static class MessageList
    {
        private static List<Message> messages = new List<Message>();
        public static List<Message> Messages { get { return messages; } }
        public static void AddMessage(Message message)
        {
            messages.Add(message);
        }
    }
}
