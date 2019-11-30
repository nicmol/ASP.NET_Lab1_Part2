using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potlucky.Models
{
    public class User
    {
        public User()
        {
            //sets new user image to default image
            if (ImageUrl == null){
                ImageUrl = "/Images/user-icon-image-placeholder.jpg";
            }
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FavoriteDish { get; set; }
        public bool IsFeaturedCook { get; set; }
        public string ImageUrl { get; set; }

        private List<Message> messages = new List<Message>();
        public List<Message> Messages { get { return messages; } }
    }
}
