using System;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde.Pages.Places
{
    public class UpdatePlace : PageModel
    {
        public Place Place { get; set; }
        
        private IPlacesCatalog catalog;

        public UpdatePlace(IPlacesCatalog catalogPlaces)
        {
            catalog = catalogPlaces;
        }
        
        public IActionResult OnGet(String id)
        {
            Place = catalog.GetPlaceById(id);
            if (Place == null) return RedirectToPage("/NotFound");
            return Page();

        }
    }
}