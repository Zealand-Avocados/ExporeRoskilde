using System;

namespace ExploreRoskilde.Models
{
    public enum Rating
    {
        One,
        Two,
        Three,
        Four,
        Five,
    }

    public class Place
    {

        public Place()
        {
            Id = Guid.NewGuid().ToString("N");
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Address Address { get; set; }
        public Rating Rating { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return Id + Title + Description;
        }
    }
}
