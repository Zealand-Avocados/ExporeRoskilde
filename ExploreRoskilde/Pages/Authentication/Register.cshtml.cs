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
        [BindProperty] 
        public new User User { get; set; }
        [BindProperty]
        public string Password1 { get; set; }
        [BindProperty]
        public string Password2 { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Password1 != Password2)
            {
                HttpContext.Session.SetString("erMessage", "passwords dont match");
                return Page();
            }
                
            User.Password = Password1;

            Dictionary<string, User> usersCatalog = Database.Database._users;

            usersCatalog.Add(User.Id, User);
            HttpContext.Session.SetString("user", User.UserName);


            return RedirectToPage("../Index");
        }
    }
}