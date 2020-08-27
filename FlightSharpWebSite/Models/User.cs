using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSharpWebSite.Models
{
    public class User
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }


        public void initHardcodedUser()
        {
            this.FristName = "yes";
            this.LastName = "Olic";
            this.Email = "gaowaak@pte.com";
            this.UserName = "builder";
        }
    }
}
