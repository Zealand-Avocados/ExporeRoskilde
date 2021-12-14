using System;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using ExploreRoskilde.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde.Pages.Places
{
    public class UpdatePlace : PageModel
    {
        [BindProperty] public Place Place { get; set; }
        
        private IPlacesCatalog catalog;
        

        public UpdatePlace(IPlacesCatalog catalogPlaces)
        {
            catalog = catalogPlaces;
        }
        
        public IActionResult OnGet(String id)
        {
            Place = catalog.GetPlaceById(id);
            if (Place == null) return RedirectToPage("./NotFound");
            return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.UpdatePlace(Place);
            return RedirectToPage("/Index");
        }
    }
}