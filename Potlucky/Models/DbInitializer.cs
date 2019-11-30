using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potlucky.Models
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                context.AddRange
                (
                    new User
                    {
                        FirstName = "Nicolette",
                        LastName = "Molitor",
                        Email = "molitorn@my.lanecc.edu",
                        ImageUrl = "/images/rawturkey.jpg"
                    },
                    new User
                    {
                        FirstName = "Dylan",
                        LastName = "Bragg",
                        Email = "db@test.com",
                        ImageUrl = "/images/hotdog.jpg"
                    },
                    new User
                    {
                        FirstName = "Cora",
                        LastName = "Molitor",
                        Email = "cm@test.com",
                        ImageUrl = "/images/stuffing.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
