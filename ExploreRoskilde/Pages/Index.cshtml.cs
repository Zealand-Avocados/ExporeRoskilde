using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ExploreRoskilde.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public Dictionary<int, Place> AllPlaces {get; set; }
        
        IPlacesCatalog _placesCatalog;
        

        public IndexModel(ILogger<IndexModel> logger, IPlacesCatalog catalog)
        {
            _logger = logger;
            _placesCatalog = catalog;
            AllPlaces = _placesCatalog.AllPlaces();
        }

        public void OnGet()
        {
        }
    }
}