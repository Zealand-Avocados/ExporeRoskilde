using ExploreRoskilde.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreRoskilde.Pages.Places
{
    public class AddPlace : PageModel
    {
        [BindProperty] public Place Place { get; set; }

        private IPlacesCatalog placesCatalog;

        public AddPlace(IPlacesCatalog catalog)
        {
            placesCatalog = catalog;
        }

        
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Place p = Place;
            placesCatalog.AddPlace(p);
                        
            return Page();
        }
        

       
    }
}