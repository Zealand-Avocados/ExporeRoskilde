using System.ComponentModel.DataAnnotations;

namespace ExploreRoskilde.Models
{
    public class User
    { 
            [Required] [MinLength(1)] 
        public int UserId { get; set; }

            [Required] [MinLength(4)]
        public string Name { get; set; }

            [Required]
            public string Email { get; set; }

            [Required] [MinLength(8)] 
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }

}

