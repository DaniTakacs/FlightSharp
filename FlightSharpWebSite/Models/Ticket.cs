using Newtonsoft.Json;

namespace FlightSharpWebSite.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int Quantity { get; set; } = 1;

        public Flight Flight { get; set; }

        public Cart Cart { get; set; }

        public Ticket(Flight flight, int quantity)
        {
            Flight = flight;
            Quantity = quantity;
        }
        public Ticket()
        {

        }
    }
}
