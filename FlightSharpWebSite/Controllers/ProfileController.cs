using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightSharpWebSite.Areas.Identity.Data;
using FlightSharpWebSite.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace FlightSharpWebSite.Controllers
{
    [Route("Home/api")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private FlightSharpWebSiteContext _context;
        public ProfileController(FlightSharpWebSiteContext context)
        {
            _context = context;
        }
        [HttpPost("profile")]
        public IActionResult EditCustomerData(dynamic data)
        {

            var firstName = data.GetProperty("firstName").ToString();
            var lastName = data.GetProperty("lastName").ToString();
            var email = data.GetProperty("email").ToString();
            var accName = data.GetProperty("accName").ToString();
            var city = data.GetProperty("city").ToString();
            var street = data.GetProperty("street").ToString();
            var streetNum = data.GetProperty("streetN").ToString();
            ApplicationUser user = _context.Users.Include( u => u.UserAddress).SingleOrDefault(u => u.UserName == User.Identity.Name);
            user.AccountName = accName;
            user.Email = email;
            user.UserAddress.City = city;
            user.UserAddress.Street = street;
            user.UserAddress.StreetNumber = streetNum;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.UserAddress.Country = email;
            _context.SaveChanges();


            return Ok();
        }
    }
}
