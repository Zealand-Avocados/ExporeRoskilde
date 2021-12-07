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

        [Required(ErrorMessage = "ID is required")]
        [Range(1, 500)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MinLength(20)][MaxLength(250)]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Address is required")]
        public Address Address { get; set; }

        [Required(ErrorMessage = "Rating is required, select a number 1-5")]
        public Rating Rating { get; set; }

        [Required(ErrorMessage = "Catagory is required")]
        public Category Category { get; set; }

        public override string ToString()
        {
            return Id + Title + Description;
        }
    }
}
