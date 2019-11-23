using Potlucky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potlucky.Repositories
{
    public interface IMessageRepository
    {
        List<Message> Messages { get; }
        void AddMessage(Message message);
        Message getMessageByDate(DateTime date);
    }
}
