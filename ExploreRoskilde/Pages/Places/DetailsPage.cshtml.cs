using System;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde.Pages.Places
{
    public class DetailsPage : PageModel
    {
        
        public Place Place { get; set; }
        
        private IPlacesCatalog placesCatalog;

        public DetailsPage(IPlacesCatalog catalog)
        {
            placesCatalog = catalog;
        }
        
        public IActionResult OnGet(String id)
        {
            Place = placesCatalog.GetPlaceById(id);
            if (Place == null) return RedirectToPage("/NotFound");
            return Page();
        }
    }
}