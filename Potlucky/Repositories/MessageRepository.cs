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
                IEnumerable<Message> list = _context.Messages;
                foreach (Message m in list)
                {
                    User user = new User();
                    var query = _context.Users.Join(_context.Messages, u => u.UserId, msg => msg.Sender.UserId,
                        (u, msg) => new
                        {
                            u.UserId,
                            u.FirstName,
                            u.LastName,
                            u.Email,
                            u.FavoriteDish,
                            u.IsFeaturedCook,
                            u.ImageUrl,
                            msg.MessageId

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
                    List<Reply> replies = _context.Replies.FromSql($"SELECT * FROM dbo.Replies WHERE MessageId = {m.MessageId}").ToList();

                    //foreach (Reply reply in replies)
                    //{
                    //    List<User> users = _context.Users.FromSql($"SELECT TOP 1 * FROM dbo.Users U" +
                    //                                       $"JOIN dbo.Replies R ON R.SenderUserId = U.UserId" +
                    //                                       $"WHERE R.ReplyId = {reply.ReplyId}").ToList();
                    //    m.AddReply(reply);
                    //}


                }

                return list.ToList();
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


        //public void AddReplyToMessage();
    }
}
