namespace ExploreRoskilde.Models
{
    public class Address
    {

        public Address(string street, string city, string zipcode, string county)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
            Country = county;
        }

        public Address()
        {
        }


        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }


        public override string ToString() => $"{Street}, {City}, {Zipcode}, {Country}";
    }
}