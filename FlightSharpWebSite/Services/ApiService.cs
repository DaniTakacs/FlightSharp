using FlightSharpWebSite.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightSharpWebSite
{
    public class ApiService
    {
        public int FlightsCounted { get; private set; }

        public ApiService()
        {
        }

        private string GetResponseAsString(string destination)
        {
            string baseUrl =
                "https://travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com/v1/prices/cheap?destination={0}&origin=BUD&currency=HUF&page=None";
            string url = string.Format(baseUrl, destination);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", "237f37871102101c4ec439ba6c98520e");
            request.AddHeader("x-rapidapi-host", "travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "22f98697d5mshbe41e4f988558c4p113d77jsnb304fc8f16d7");
            IRestResponse response = client.Execute(request);
            string cont = response.Content;

            return cont;
        }

        private int CountResults(string resp)
        {
            return resp.Count(f => f == '{') - 3;
        }

        /*public void GetFlightsFromBUDToBER()
        {
            var client =
                new RestClient(
                    "https://travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com/v1/prices/cheap?destination=BER&origin=BUD&currency=HUF&page=None");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", "237f37871102101c4ec439ba6c98520e");
            request.AddHeader("x-rapidapi-host", "travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "8cc5a982f3msha7010a92e8c909ap14602cjsneeae413a870c");
            IRestResponse response = client.Execute(request);
            var FullJson = response.Content;

            var json = JObject.Parse(FullJson);
            var allBerlinFlights = json["data"]["BER"];

            List<Flight> flightList = new List<Flight>();

            for (int i = 0; i < allBerlinFlights.Count(); i++)
            {
                var price = (string)json.SelectToken("data.BER." + i + ".price");
                var airline = (string)json.SelectToken("data.BER." + i + ".airline");
                var flightNum = (string)json.SelectToken("data.BER." + i + ".flight_number");
                var departure = (string)json.SelectToken("data.BER." + i + ".departure_at");
                var returnTime = (string)json.SelectToken("data.BER." + i + ".return_at");
                ;
                var expireAt = (string)json.SelectToken("data.BER." + i + ".expire_at");

                var something = new Flight(price, airline, flightNum, departure, returnTime, expireAt);

                flightList.Add(something);
            }

            foreach (var flight in flightList)
            {
                Console.WriteLine(flight.ToString());
            }
        }*/

        public void GetFlightsFromTo(string from, string to)
        {
            string url = "https://travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com/v1/prices/cheap?destination={0}&origin={1}&currency=HUF&page=None";
            string exactURL = string.Format(url, to, from);

            var client = new RestClient(exactURL);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", "237f37871102101c4ec439ba6c98520e");
            request.AddHeader("x-rapidapi-host", "travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "8cc5a982f3msha7010a92e8c909ap14602cjsneeae413a870c");
            IRestResponse response = client.Execute(request);
            var FullJson = response.Content;

            var json = JObject.Parse(FullJson);
            var allFlights = json["data"][to];

            List<Flight> flightList = new List<Flight>();

            for (int i = 0; i < CountResults(FullJson); i++)
            {
                var price = (string)json.SelectToken("data." + to + "." + i + ".price");
                var airline = (string)json.SelectToken("data." + to + "." + i + ".airline");
                var flightNum = (string)json.SelectToken("data." + to + "." + i + ".flight_number");
                var departure = (string)json.SelectToken("data." + to + "." + i + ".departure_at");
                var returnTime = (string)json.SelectToken("data." + to + "." + i + ".return_at");

                var expireAt = (string)json.SelectToken("data." + to + "." + i + ".expire_at");

                var something = new Flight(price, airline, flightNum, departure, returnTime, expireAt, to);

                flightList.Add(something);
            }

            foreach (var flight in flightList)
            {
                Console.WriteLine(flight.ToString());
            }
        }
    }
}