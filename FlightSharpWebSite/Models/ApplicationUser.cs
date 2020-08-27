using Microsoft.AspNetCore.Identity;

namespace FlightSharpWebSite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }
        public UserAddress Address { get; set; }

    }
}
