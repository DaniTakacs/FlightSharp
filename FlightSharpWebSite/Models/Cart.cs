using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FlightSharpWebSite.Areas.Identity.Data;

namespace FlightSharpWebSite.Models
{
    public class Cart
    {
        //public List<Flight> BookedFlights;
        //
        public string CartId { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ApplicationUser ApplicationUser { get; set; }


        public Cart()
        {
            Tickets = new List<Ticket>();
        }

        public bool AddToCart(Flight flight, int quantity)
        {
            try
            {
                if (IsInCart(flight))
                {
                    UpdateQuantity(flight, quantity);
                }
                else
                {
                    Tickets.Add(new Ticket(flight, quantity));
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public void DeleteFromCart(Flight flight)
        {
            var ticket = Tickets.Where(t => t.Flight.Equals(flight)).FirstOrDefault();
            Tickets.Remove(ticket);
        }

        public void UpdateQuantity(Flight flight, int quantity)
        {
            var ticket = Tickets.Where(x => x.Flight.Equals(flight))
                .Select(x => x)
                .FirstOrDefault();

            ticket.Quantity += quantity;
            if (ticket.Quantity == 0)
            {
                DeleteFromCart(flight);
            }
               
        }

        public bool IsInCart(Flight flight)
        {
            return Tickets.Any(x => x.Flight.Equals(flight));
        }
    }
}