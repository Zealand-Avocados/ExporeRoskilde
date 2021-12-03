namespace ExploreRoskilde.Models
{
    public class Address
    {
        

        public Address (string street, string city, string zipcode, string county)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
            Country = county;
        }
        
        public string Street { get; }
        public string City { get; }
        public string Zipcode { get; }
        public string Country { get; }

    }
}