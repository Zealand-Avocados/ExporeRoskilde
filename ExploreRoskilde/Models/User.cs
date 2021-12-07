using System.ComponentModel.DataAnnotations;

namespace ExploreRoskilde.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(1)] 
        public int UserId { get; set; }

            [Required] [MinLength(4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email is incorrect, please try again")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }

}

