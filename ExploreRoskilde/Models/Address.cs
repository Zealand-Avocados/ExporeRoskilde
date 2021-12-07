using System.ComponentModel.DataAnnotations;

namespace ExploreRoskilde.Models
{
    public class Address
    {
        private string _street { get; }
        private string _city { get; }
        private string _zipcode { get; }
        private string _country { get; }

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

        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string Country { get; set; }


        public override string ToString() => $"{Street}, {City}, {Zipcode}, {Country}";
    }
}
