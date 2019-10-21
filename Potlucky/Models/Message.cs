using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potlucky.Models
{
    public class Message
    {
        public string MessageText { get; set; }
        public User Sender { get; set; }
        public DateTime Date { get; set; 

        private List<Reply> replies = new List<Reply>();
        public List<Reply> Replies { get { return replies; } }
        
    }
}
