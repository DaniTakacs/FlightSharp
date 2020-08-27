namespace FlightSharpWebSite.Models
{
    public class UserAddress
    {
        public int UserAddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public int PostalCode { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}