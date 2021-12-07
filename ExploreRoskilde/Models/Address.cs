using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Street name is required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City name is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Zipcode is required")]
        public string Zipcode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }


        public override string ToString() => $"{Street}, {City}, {Zipcode}, {Country}";
    }
}
