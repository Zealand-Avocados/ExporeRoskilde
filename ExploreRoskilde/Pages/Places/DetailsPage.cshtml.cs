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
        [BindProperty] public String IdPlace { get; set; }


        [BindProperty] public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }

        private readonly IPlacesCatalog _placesCatalog;
        private readonly ICommentsCatalog _commentsCatalog;

        public DetailsPage(IPlacesCatalog catalog, ICommentsCatalog cCatalog)
        {
            _placesCatalog = catalog;
            _commentsCatalog = cCatalog;
        }

        public IActionResult OnGet(String id)
        {
            ModelState.Clear();
            Place = _placesCatalog.GetPlaceById(id);
            if (Place == null) return RedirectToPage("/NotFound");
            Comments = _commentsCatalog.GetCommentsByPlaceId(id);
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
    }
}