using System;

namespace ExploreRoskilde.Models
{
    public class UserFavourites
    {
        public UserFavourites()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public string Id { get; set; }
        public string IdPlace { get; set; }
        public string Username { get; set; }
    }
}