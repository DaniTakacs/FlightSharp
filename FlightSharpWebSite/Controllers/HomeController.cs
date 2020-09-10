using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlightSharpWebSite.Models;
using FlightSharpWebSite.Services;
using FlightSharpWebSite.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using FlightSharpWebSite.Data;

namespace FlightSharpWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SessionService _sessionService;
        private FlightSharpWebSiteContext _context;

        public HomeController(ILogger<HomeController> logger, SessionService session, FlightSharpWebSiteContext context)
        {
            _logger = logger;
            _sessionService = session;
            _context = context;
        }

        public IActionResult Index()
        {
            //var cart = _sessionService.GetSessionObject<Cart>("Cart");

            //if (cart == null)
            //{
            //    cart = new Cart();

            //    _sessionService.SetSessionString("userName", "anonym");
            //    _sessionService.SetSessionObject("Cart", cart);
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Profile()
        {
            ApplicationUser user = _context.Users.SingleOrDefault( u => u.Email == User.Identity.Name);

            ViewData["Profile"] = user;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
