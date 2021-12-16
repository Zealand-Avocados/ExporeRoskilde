using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Http;
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
            HttpContext.Session.SetString("erMessage", "");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (User.Email == null || User.Username == null || Password1 == null || Password2 == null)
            {
                HttpContext.Session.SetString("erMessage", "All fields must be filled up");
                return Page();
            }

            if (Password1 != Password2)
            {
                HttpContext.Session.SetString("erMessage", "Passwords dont match");
                return Page();
            }

            User.Password = Password1;

            if (!_userService.Register(User))
            {
                HttpContext.Session.SetString("erMessage", "Email is used");
                return Page();
            }
           
            HttpContext.Session.SetString("user", User.Username);
            HttpContext.Session.SetString("rights", "normal");
            HttpContext.Session.SetString("erMessage", "");
            return RedirectToPage("../Index");
        }
    }
}