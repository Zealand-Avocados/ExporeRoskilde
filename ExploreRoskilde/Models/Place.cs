using System;
using System.ComponentModel.DataAnnotations;

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

        [Required, Range(1, 500)] public string Id { get; set; }
        [Required] public string Title { get; set; }

        [Required, MinLength(10), MaxLength(250)]
        public string Description { get; set; }

        [Required] public Address Address { get; set; }
        [Required] public Rating Rating { get; set; }
        [Required] public Category Category { get; set; }

        public override string ToString()
        {
            return Id + Title + Description;
        }
    }
}