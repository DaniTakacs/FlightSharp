using Microsoft.AspNetCore.Identity;

namespace FlightSharpWebSite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public UserAddress Address { get; set; }

    }
}
