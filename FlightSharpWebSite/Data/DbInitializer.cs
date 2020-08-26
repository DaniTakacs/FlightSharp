    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightSharpWebSite.Models;

namespace FlightSharpWebSite.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.WebUsers.Any())
            {
                return;
            }

            var webUsers = new WebUser[]
            {
                new WebUser
                {
                    Email="testmintaanna@gmail.com",
                    PasswordHashed="atmNotHashed1",
                    Salt="salt1",
                    UserAccount = new UserAccount{UserName="MintaAnna"},
                },
                new WebUser
                {
                    Email = "testadminpeter@gmail.com",
                    PasswordHashed = "atmNotHashed2",
                    Salt = "salt2",
                    UserAccount = new UserAccount{UserName="AdminPeter", WebUserId=2},
                },
            };

            foreach (var user in webUsers)
            {
                context.WebUsers.Add(user);
            }
            context.SaveChanges();
        }
    }
}
