using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde.Pages
{
    public class ProfilePage : PageModel
    {
        private readonly IUsersCatalog _userService;
        private readonly IUserFavouritesCatalog _userFavouritesCatalog;
        private readonly IPlacesCatalog _placesCatalog;

        public ProfilePage(IUserFavouritesCatalog uCatalog, IUsersCatalog service, IPlacesCatalog catalog)
        {
            _userService = service;
            _userFavouritesCatalog = uCatalog;
            _placesCatalog = catalog;
            UserFavouritesList = new List<Place>();

        }

        public User LoggedUser { get; set; }
        public List<Place> UserFavouritesList { get; set; }
        
        
        public IActionResult OnGet()
        {
            string user = HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(user)) return RedirectToPage("../Authentication/Login");
            User foundUser = _userService.GetUserByUsername(user);
            if (foundUser == null) return RedirectToAction("Index");
            LoggedUser = foundUser;
            foreach (UserFavourites i in _userFavouritesCatalog.GetUserFavouritesByUsername(user))
            {
                UserFavouritesList.Add(_placesCatalog.GetPlaceById(i.IdPlace));
            }
            
            return Page();
        }
    }
}