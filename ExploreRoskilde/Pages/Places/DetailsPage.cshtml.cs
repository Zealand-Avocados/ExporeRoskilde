using System;
using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde.Pages.Places
{
    public class DetailsPage : PageModel
    {
        public Place Place { get; set; }
        public bool IsUserFavourite { get; set; }
        [BindProperty] public String IdPlace { get; set; }


        [BindProperty] public Comment Comment { get; set; }

        [BindProperty] public UserFavourites UserFavourites { get; set; }
        public List<Comment> Comments { get; set; }

        private readonly IPlacesCatalog _placesCatalog;
        private readonly ICommentsCatalog _commentsCatalog;
        private readonly IUserFavouritesCatalog _userFavouritesCatalog;

        public DetailsPage(IPlacesCatalog catalog, ICommentsCatalog cCatalog, IUserFavouritesCatalog uCatalog)
        {
            _placesCatalog = catalog;
            _commentsCatalog = cCatalog;
            _userFavouritesCatalog = uCatalog;
        }

        public IActionResult OnGet(String id)
        {
            ModelState.Clear();
            Place = _placesCatalog.GetPlaceById(id);
            if (Place == null) return RedirectToPage("./NotFound");
            Comments = _commentsCatalog.GetCommentsByPlaceId(id);
            IsUserFavourite = _userFavouritesCatalog.IsUserFavourite(id, HttpContext.Session.GetString("user"));

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string user = HttpContext.Session.GetString("user");
            if (String.IsNullOrEmpty(user)) return Page();
            Comment.IdPlace = IdPlace;
            Comment.Username = user;
            _commentsCatalog.AddComment(Comment);
            ModelState.Clear();
            return OnGet(IdPlace);
        }

        public IActionResult OnPostAddUserFavourites()
        {
            string user = HttpContext.Session.GetString("user");
            if (String.IsNullOrEmpty(user)) return Page();
            UserFavourites.IdPlace = IdPlace;
            UserFavourites.Username = user;
            _userFavouritesCatalog.AddUserFavourite(UserFavourites);
            ModelState.Clear();
            return OnGet(IdPlace);
        }


        public IActionResult OnPostRemoveUserFavourites()
        {
            string user = HttpContext.Session.GetString("user");
            if (String.IsNullOrEmpty(user)) return Page();
            _userFavouritesCatalog.DeleteUserFavourite(IdPlace, user);
            ModelState.Clear();
            return OnGet(IdPlace);
        }
    }
}