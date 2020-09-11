using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlightSharpWebSite.Areas.Identity.Data;

namespace FlightSharpWebSite.Models
{
    public class UserAddress
    {
        [MaxLength(15)]
        public string Country { get; set; }
        [MaxLength(15)]
        public string City { get; set; }
        [MaxLength(15)]
        public string Street { get; set; }
        [MaxLength(3)]
        public string StreetNumber { get; set; }
        [MaxLength(6)]
        public string PostalCode { get; set; }

        public string UserAddressId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
