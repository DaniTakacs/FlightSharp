using FlightSharpWebSite.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightSharpWebSite.Services
{
    public class ApiService
    {
        public int FlightsCounted { get; private set; }
        public ApiService()
        {

        }

        /// <summary>
        /// Creates url for the current info request, connects to API to get data
        /// </summary>
        /// <param name="to">Destination</param>
        /// <param name="from">Origin</param>
        /// <returns>string responseContent</returns>
        public string GetResponseAsString(string to, string from)
        {
            string baseUrl = "https://travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com/v1/prices/cheap?destination={0}&origin={1}&currency=HUF&page=None";
            string url = string.Format(baseUrl, to, from);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", "237f37871102101c4ec439ba6c98520e");
            request.AddHeader("x-rapidapi-host", "travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "22f98697d5mshbe41e4f988558c4p113d77jsnb304fc8f16d7");
            IRestResponse response = client.Execute(request);
            string cont = response.Content;

            return cont;
        }

        public int CountResults(string resp)
        {
            return resp.Count(f => f == '{') - 3;
        }

        /// <summary>
        /// Parses the string response then sets the flights
        /// </summary>
        /// <param name="response"></param>
        /// <param name="destination"></param>
        /// <returns>List of Flights</returns>
        public List<Flight> GetFlightsFromTo(string response, string destination)
        {
            var json = JObject.Parse(response);
            var allFlights = json["data"][destination];

            List<Flight> flightList = new List<Flight>();

            for (int i = 0; i < CountResults(response); i++)
            {
                var price = (string)json.SelectToken("data." + destination + "." + i + ".price");
                var airline = (string)json.SelectToken("data." + destination + "." + i + ".airline");
                var flightNum = (string)json.SelectToken("data." + destination + "." + i + ".flight_number");
                var departure = (string)json.SelectToken("data." + destination + "." + i + ".departure_at");
                var returnTime = (string)json.SelectToken("data." + destination + "." + i + ".return_at");

                var expireAt = (string)json.SelectToken("data." + destination + "." + i + ".expire_at");

                var something = new Flight(price, airline, flightNum, departure, returnTime, expireAt, destination);

                flightList.Add(something);
            }

            return flightList;
        }
    }
}

