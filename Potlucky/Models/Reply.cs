using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potlucky.Models
{
    public class Reply
    {
        public string MessageText { get; set; }
        public User Sender { get; set; }
        public DateTime Date { get; set; }
    }
}
