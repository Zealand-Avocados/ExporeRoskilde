using ExploreRoskilde.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreRoskilde.Pages.Places
{
    public class AddPlace : PageModel
    {
        public Place Place { get; set; }

        private IPlacesCatalog placesCatalog;
        public AddPlace(IPlacesCatalog catalog)
        {
            placesCatalog = catalog;
        }
        
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            placesCatalog.AddPlace(
                new Place(2, "asd", "asdsa", Rating.Five, new Address("asd", "asd", "asd", "asd "), Category.Art)
            );

            return Page();
        }
    }
}