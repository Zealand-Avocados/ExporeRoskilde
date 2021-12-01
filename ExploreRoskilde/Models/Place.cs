namespace ExploreRoskilde.Models
{
    public enum Rating
    {
        One, Two, Three, Four, Five,
    }
    
    
    
    
    public class Place
    {
        public Place(
            string id,  string title,  string description, Rating rating, Address address, Category category
        )
        {
            Id = id;
            Title = title;
            Description = description;
            Rating = rating;
            Address = address;
            Category = category;
        }



        public string Id { get; }
        public string Title { get; }
        public string Description { get; }
        public Address Address { get; }
        public Rating Rating { get; }
        public Category Category { get; }
        
    }
}