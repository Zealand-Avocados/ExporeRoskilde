using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde
{
    public class RegisterModel : PageModel
    {
        private IUsersCatalog _userService;
        [BindProperty] 
        public new User User { get; set; }
        [BindProperty]
        public string Password1 { get; set; }
        [BindProperty]
        public string Password2 { get; set; }

        public RegisterModel(IUsersCatalog services)
        {
            _userService = services;
        }

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


            _userService.Register(User);
           
            HttpContext.Session.SetString("user", User.Username);

            return RedirectToPage("../Index");
        }
    }
}