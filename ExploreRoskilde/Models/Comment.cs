using System;
using System.ComponentModel.DataAnnotations;

namespace ExploreRoskilde.Models
{
    public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid().ToString("N");

        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string IdPlace { get; set; }

        [Required(ErrorMessage = "You have to write at least a little bit")]
        [MinLength(5)][MaxLength(250)]
        public string Text { get; set; }
    }
}