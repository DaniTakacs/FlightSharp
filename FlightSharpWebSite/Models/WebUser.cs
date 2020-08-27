using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSharpWebSite.Models
{
    public class WebUser
    {
        public int WebUserId { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public string Salt { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
