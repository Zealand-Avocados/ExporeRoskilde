using System.ComponentModel.DataAnnotations;

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



        [Required] [Range(1,500)]
        public string Id { get; }
        [Required]

        public string Title { get; }
        [Required][Range(1, 250)]

        public string Description { get; }
        [Required]

        public Address Address { get; }

        [Range(1,5)]
        public Rating Rating { get; }
        [Required]

        public Category Category { get; }
        
    }
}