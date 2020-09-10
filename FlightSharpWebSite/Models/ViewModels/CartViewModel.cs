using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSharpWebSite.Models.ViewModels
{
    public class CartViewModel
    {
        public ICollection<TicketViewModel> Tickets { get; set; }
        public CartViewModel()
        {
            Tickets = new List<TicketViewModel>();
        }
    }
}
