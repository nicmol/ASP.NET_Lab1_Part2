using Potlucky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                IEnumerable<Message> list = _context.Messages;
                foreach (Message m in list)
                {
                    User user = new User();
                    var query = _context.Users.Join(_context.Messages, u => u.UserId, msg => msg.Sender.UserId,
                        (u, msg) => new
                        {
                            UserId = u.UserId,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            FavoriteDish = u.FavoriteDish,
                            IsFeaturedCook = u.IsFeaturedCook,
                            ImageUrl = u.ImageUrl,
                            MessageId = msg.MessageId

                        }
                    ).Where(u => u.MessageId == m.MessageId);


                    foreach (var q in query)
                    {
                        user.UserId = q.UserId;
                        user.FirstName = q.FirstName;
                        user.LastName = q.LastName;
                        user.Email = q.Email;
                        user.FavoriteDish = q.FavoriteDish;
                        user.IsFeaturedCook = q.IsFeaturedCook;
                        user.ImageUrl = q.ImageUrl;

                        break;
                    }

                    m.Sender = user;
                }


                return list.ToList();
            }
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
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

        //public void AddReplyToMessage();

    }
}
