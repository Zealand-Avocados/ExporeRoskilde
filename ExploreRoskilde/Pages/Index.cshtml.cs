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
        
        public Dictionary<string, Place> AllPlaces {get; set; }


        public IndexModel(ILogger<IndexModel> logger, IPlacesCatalog catalog)
        {
            _logger = logger;
            AllPlaces = catalog.AllPlaces();
        }

        public void OnGet()
        {
        }
    }
}