using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde.Pages.Places
{
    public class Places : PageModel
    {
        public Dictionary<int, Place> AllPlaces {get; set; }
        
        IPlacesCatalog _placesCatalog;


        public Places(IPlacesCatalog catalog)
        {
            _placesCatalog = catalog;
            AllPlaces = _placesCatalog.AllPlaces();
        }

        public void OnGet()
        {
            
        }
        
        
        
    }
}