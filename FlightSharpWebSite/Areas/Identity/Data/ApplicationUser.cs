using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightSharpWebSite.Models;
using Microsoft.AspNetCore.Identity;

namespace FlightSharpWebSite.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserAddress UserAddress { get; set; }

    }
}
