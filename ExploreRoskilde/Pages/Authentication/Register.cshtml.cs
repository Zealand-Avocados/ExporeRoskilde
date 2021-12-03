using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreRoskilde.Catalogs;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        
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

            Dictionary<int, User> usersCatalog = Database.Database._users;

            usersCatalog.Add(usersCatalog.Count == 0 ? 0 : usersCatalog.Values.Last().UserId + 1, User);

            return RedirectToPage("../Index");
        }
    }
}
