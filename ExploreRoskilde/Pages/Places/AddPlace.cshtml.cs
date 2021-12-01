using Microsoft.AspNetCore.Mvc.RazorPages;
using ExploreRoskilde.Models;

namespace ExploreRoskilde.Pages.Places
{
    public class AddPlace : PageModel
    {
        public Place Place { get; set; } 

        public void OnGet()
        {
            
        }
    }
}