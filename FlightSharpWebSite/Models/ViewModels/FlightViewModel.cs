using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FlightSharpWebSite.Models.ViewModels
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd hh:mm}")]
        [JsonProperty("return_at")]
        public DateTime Return { get; set; }

        [JsonProperty("price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int PriceHUF { get; set; }

        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd hh:mm}")]
        [JsonProperty("departure_at")]
        public DateTime Departure { get; set; }

        [JsonProperty("flight_number")]
        [Required]
        public int FlightNo { get; set; }

        [JsonProperty("airline")]
        public string AirLine { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd hh:mm}")]
        [JsonProperty("expires_at")]
        public DateTime ExpirationDate { get; set; }
    }
}
