using System.Linq;
using FlightSharpWebSite.Models;
using Microsoft.AspNetCore.Identity;

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

            var hasher = new PasswordHasher<WebUser>();

            var webUsers = new WebUser[]
            {
                new WebUser
                {
                    Email="testmintaanna@gmail.com",
                    PasswordHashed= hasher.HashPassword(null, "mintaanna"),
                    Salt="salt1",
                    UserAccount = new UserAccount{UserName="MintaAnna"},
                },
                new WebUser
                {
                    Email = "testadminpeter@gmail.com",
                    PasswordHashed = hasher.HashPassword(null, "adminpeter"),
                    Salt = "salt2",
                    UserAccount = new UserAccount{UserName="AdminPeter"},
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
