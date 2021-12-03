namespace ExploreRoskilde.Models
{
    public class Address
    {
        private string _street { get; }
        private string _city { get; }
        private string _zipcode { get; }
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