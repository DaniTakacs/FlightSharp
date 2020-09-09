using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlightSharpWebSite.Models;
using Microsoft.AspNetCore.Identity;

namespace FlightSharpWebSite.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(10)]
        public string FirstName { get; set; }
        [MaxLength(15)]
        public string LastName { get; set; }

        [MaxLength(15)]
        public string AccountName { get; set; }
        public UserAddress UserAddress { get; set; }

    }
}
