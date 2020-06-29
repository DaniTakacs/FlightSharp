using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FlightSharpWebSite.Models
{
    public class Flight
    {
        [JsonPropertyName("price")] public string PriceHUF { get; set; }
        [JsonPropertyName("airline")] public string Airline { get; set; }
        [JsonPropertyName("flight_number")] public string FlightNum { get; set; }
        [JsonPropertyName("departure_at")] public string DepartureTime { get; set; }
        [JsonPropertyName("return_at")] public string ReturnTime { get; set; }
        [JsonPropertyName("expire_at")] public string ExpireTime { get; set; }
        public string Destination { get; set; }

        public override string ToString() => "Flight Number: " + FlightNum + " Date: " + DepartureTime +
                                             " Price in HUF: " + PriceHUF;

        public Flight(string priceHuf, string airline, string flightNum, string departureTime, string returnTime,
            string expireTime)
        {
            PriceHUF = priceHuf;
            Airline = airline;
            FlightNum = flightNum;
            DepartureTime = departureTime;
            ReturnTime = returnTime;
            ExpireTime = expireTime;
        }
    }
}