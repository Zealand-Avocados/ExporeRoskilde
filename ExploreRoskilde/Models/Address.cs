using System.ComponentModel.DataAnnotations;

namespace ExploreRoskilde.Models
{
    public class Address
    {
        [Required]
        private string _street { get; }

        [Required]
        private string _city { get; }

        [Required]
        private string _zipcode { get; }

        [Required]
        private string _country { get; }

        public Address (string street, string city, string zipcode, string county)
        {
            _street = street;
            _city = city;
            _zipcode = zipcode;
            _country = county;
        }

    }
}