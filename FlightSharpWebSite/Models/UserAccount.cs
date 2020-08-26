using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSharpWebSite.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string UserName { get; set; }

        public int WebUserId { get; set; }
        public WebUser WebUser { get; set; }
    }
}
