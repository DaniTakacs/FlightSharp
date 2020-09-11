using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using FlightSharpWebSite.Areas.Identity.Data;
using FlightSharpWebSite.Data;
using FlightSharpWebSite.Models;
using FlightSharpWebSite.Models.ViewModels;
using FlightSharpWebSite.Services;
using FlightSharpWebSite.Util;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace FlightSharpWebSite.Controllers
{
    [Route("Home/api")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly SessionService _sessionService;
        private FlightSharpWebSiteContext _context;

        public CartController(SessionService sessionService, FlightSharpWebSiteContext context)
        {
            _sessionService = sessionService;
            _context = context;
        }


        [HttpGet]
        public ViewResult Get()
        {
            var cartDTO = _sessionService.GetSessionObject<CartViewModel>("Cart");

            if (cartDTO == null || cartDTO.Tickets.Count == 0)
            {
                cartDTO = new CartViewModel();

                if (User.Identity.IsAuthenticated)
                {
                    var currentUser = this.User;
                    var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                    ApplicationUser user = _context.Users
                        .Include(u => u.Cart)
                        .ThenInclude(c => c.Tickets)
                        .ThenInclude(t => t.Flight)
                        .SingleOrDefault(u => u.Id == userId);

                    if (user.Cart == null)
                    {
                        user.Cart = new Cart();
                    }

                    var tickets = from ticket in user.Cart.Tickets
                                  select new TicketViewModel
                                  {
                                      Quantity = ticket.Quantity,
                                      Flight = new FlightViewModel
                                      {
                                          FlightId = ticket.Flight.FlightId,
                                          Return = ticket.Flight.Return,
                                          PriceHUF = ticket.Flight.PriceHUF,
                                          Origin = ticket.Flight.Origin,
                                          Destination = ticket.Flight.Destination,
                                          Departure = ticket.Flight.Departure,
                                          FlightNo = ticket.Flight.FlightNo,
                                          AirLine = ticket.Flight.AirLine,
                                          ExpirationDate = ticket.Flight.ExpirationDate
                                      }
                                  };
                

                    cartDTO.Tickets = tickets.ToList();
                }

                //TODO SET these sessions in homepage!
                //_sessionService.SetSessionString("userName", "anonym");
                _sessionService.SetSessionObject("Cart", cartDTO);
            }

            //ViewData["Cart"] = cartDTO;

            return View("~/Views/Home/Cart.cshtml", cartDTO);
        }

        //[HttpPost("cart")]
        //public HttpStatusCode AddFlight(Ticket ticket)
        //{
        //    var cart = HttpContext.Session.GetObject<Cart>("Cart");
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        // return HttpStatusCode.BadRequest;
        //    }

        //    var flight = ticket.Flight;
        //    var quantity = ticket.Quantity;

        //    if (!cart.AddToCart(flight, quantity))
        //    {
        //        // this actually could happen either due to server error or bad query
        //        return HttpStatusCode.InternalServerError;
        //    }
        //    _sessionService.SetSessionObject("Cart", cart);
        //    return HttpStatusCode.OK;
        //}

        [HttpPost("cart")]
        public IActionResult AddFlight(dynamic data)
        {
            Cart cart = new Cart();
            Flight flightModel;
            FlightViewModel flightVM;
            int quantity;
            var cartVM = _sessionService.GetSessionObject<CartViewModel>("Cart");

            if (cartVM == null)
            {
                return NotFound();
            }

            try
            {
                var flight = data.GetProperty("Flight").ToString();
                var parsedQuantity = data.GetProperty("Quantity").GetInt32();
                quantity = parsedQuantity;

                // TODO ISSUE #1 The deserializer prevents any malformed input to enter.
                // So code in the if block below always returns true.
                // Need to add restrictions to the Cart class,
                // to have a minimum necessary properties.
                flightVM = JsonSerializer.Deserialize<FlightViewModel>(flight);

                flightModel = new Flight
                {
                    FlightId = flightVM.FlightId,
                    Return = flightVM.Return,
                    PriceHUF = flightVM.PriceHUF,
                    Origin = flightVM.Origin,
                    Destination = flightVM.Destination,
                    Departure = flightVM.Departure,
                    FlightNo = flightVM.FlightNo,
                    AirLine = flightVM.AirLine,
                    ExpirationDate = flightVM.ExpirationDate
                };
                var ticketModel = from ticket in cartVM.Tickets
                                    select new Ticket
                                    {
                                        Quantity = ticket.Quantity,
                                        Flight = new Flight
                                        {
                                            FlightId = ticket.Flight.FlightId,
                                            Return = ticket.Flight.Return,
                                            PriceHUF = ticket.Flight.PriceHUF,
                                            Origin = ticket.Flight.Origin,
                                            Destination = ticket.Flight.Destination,
                                            Departure = ticket.Flight.Departure,
                                            FlightNo = ticket.Flight.FlightNo,
                                            AirLine = ticket.Flight.AirLine,
                                            ExpirationDate = ticket.Flight.ExpirationDate
                                        }
                                    };
                cart = new Cart() { Tickets = ticketModel.ToList() };

                
                if (!cart.AddToCart(flightModel, quantity))
                {
                    // this actually could happen either due to server error or bad query
                    return StatusCode(500);
                } 
                else
                {
                    var ticketBackComp = from ticket in cart.Tickets
                                      select new TicketViewModel
                                      {
                                          Quantity = ticket.Quantity,
                                          Flight = new FlightViewModel
                                          {
                                              FlightId = ticket.Flight.FlightId,
                                              Return = ticket.Flight.Return,
                                              PriceHUF = ticket.Flight.PriceHUF,
                                              Origin = ticket.Flight.Origin,
                                              Destination = ticket.Flight.Destination,
                                              Departure = ticket.Flight.Departure,
                                              FlightNo = ticket.Flight.FlightNo,
                                              AirLine = ticket.Flight.AirLine,
                                              ExpirationDate = ticket.Flight.ExpirationDate
                                          }
                                      };
                    cartVM.Tickets = ticketBackComp.ToList();
                }
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

            if (User.Identity.IsAuthenticated)
            {
                var currentUser = this.User;
                var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                ApplicationUser user = _context.Users
                    .Include(u => u.Cart)
                    .ThenInclude(c => c.Tickets)
                    .ThenInclude(t => t.Flight)
                    .SingleOrDefault(u => u.Id == userId);
                if (user.Cart == null)
                {
                    user.Cart = new Cart();
                }

                var selectedTicket = user.Cart.Tickets.Where(t => t.Flight.Equals(flightVM)).FirstOrDefault();
                if (selectedTicket != null)
                {
                    selectedTicket.Quantity += quantity;
                }
                else
                {
                    var ticket = new Ticket
                    {
                        Quantity = 1,
                        Flight = flightModel
                    };
                    user.Cart.Tickets.Add(ticket);
                }

                _context.SaveChanges();
            }

            _sessionService.SetSessionObject("Cart", cartVM);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult DeleteFlights(dynamic data)
        {
            Flight flightObject;
            var cart = _sessionService.GetSessionObject<Cart>("Cart");

            if (cart == null)
            {
                return NotFound();
            }

            try
            {
                var flight = data.GetProperty("Flight").ToString();
                flightObject = JsonSerializer.Deserialize<Flight>(flight);
                cart.DeleteFromCart(flightObject);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            if (User.Identity.IsAuthenticated)
            {
          
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                ApplicationUser user = _context.Users
                    .Include(u => u.Cart)
                    .ThenInclude(c => c.Tickets)
                    .ThenInclude(t => t.Flight)
                    .SingleOrDefault(u => u.Id == userId);

                var selectedTicket = user.Cart.Tickets.Where(t => t.Flight.Equals(flightObject)).FirstOrDefault();
                if (selectedTicket != null)
                {
                    user.Cart.Tickets.Remove(selectedTicket);
                }
                _context.SaveChanges();
            }

            _sessionService.SetSessionObject("Cart", cart);

            return Ok();
        }
    }
}
