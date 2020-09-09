using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace FlightSharpWebSite.Controllers
{
    [Route("Home/api")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpPost("profile")]
        public IActionResult EditCustomerData(dynamic data)
        {
            try
            {
                var userName = data.GetProperty("userName").ToString();
                var firstName = data.GetProperty("firstName").ToString();
                var lastName = data.GetProperty("lastName").ToString();
                var email = data.GetProperty("email").ToString();
                Console.WriteLine("first name: " + firstName);
                Console.WriteLine("email: " + email);
                Console.WriteLine("username: " + userName);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
