using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreRoskilde.Models
{
    public class User
    {
        [Required, MinLength(1)] public int UserId { get; set; }
        [Required, MinLength(4)] public string Name { get; set; }
        [Required] public string Emial { get; set; }
        [Required, MinLength(8)] public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}