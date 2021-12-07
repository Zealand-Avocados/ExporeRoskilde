using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreRoskilde.Catalogs;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde
{
    public class RegisterModel : PageModel
    {
        [BindProperty] public new User User { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Dictionary<string, User> usersCatalog = Database.Database._users;

            usersCatalog.Add(User.Id, User);
            HttpContext.Session.SetString("user", User.Id);


            return RedirectToPage("../Index");
        }
    }
}