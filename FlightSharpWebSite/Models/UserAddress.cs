using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightSharpWebSite.Areas.Identity.Data;

namespace FlightSharpWebSite.Models
{
    public class UserAddress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }

        public string UserAddressId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
