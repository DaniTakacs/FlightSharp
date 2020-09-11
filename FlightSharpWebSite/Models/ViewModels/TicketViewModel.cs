using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSharpWebSite.Models.ViewModels
{
    public class TicketViewModel
    {
        public int Quantity { get; set; } = 1;

        public FlightViewModel Flight { get; set; }

        public TicketViewModel(FlightViewModel flight, int quantity)
        {
            Flight = flight;
            Quantity = quantity;
        }
        public TicketViewModel()
        {

        }
    }
}
