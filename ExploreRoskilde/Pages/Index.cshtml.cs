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

        public Dictionary<int, User> AllUsers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Category { get; set; }


        private IPlacesCatalog catalog_places;
        private IUsersCatalog catalog_users;

        public IndexModel(ILogger<IndexModel> logger, IPlacesCatalog placescatalog, IUsersCatalog userscatalog)
        {
            _logger = logger;
            catalog_places = placescatalog;
            catalog_users = userscatalog;
        }

        public void OnGet()
        {
            AllPlaces = catalog_places.AllPlaces();
            AllUsers = catalog_users.AllUsers();

            AllPlaces = catalog_places.Searching(Search, Category);
            

        }
    }
}