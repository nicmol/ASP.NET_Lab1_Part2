using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potlucky.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        private List<Message> messages = new List<Message>();
        public List<Message> Messages { get { return messages; } }
    }
}
