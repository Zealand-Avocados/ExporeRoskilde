using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde
{
    public class LoginModel : PageModel
    {
        IUsersCatalog userService;
        [BindProperty]
        public string Username { get; set; }
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }

        public LoginModel(IUsersCatalog service)
        {
            userService = service;
        }

        public IActionResult OnGet()
        {
            HttpContext.Session.SetString("erMessage", "");
            return Page();
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("erMessage", "");
            return CheckLogin();
        }

        private IActionResult CheckLogin()
        {
            User validUser = userService.Login(Email, Password);
            if (validUser != null)
            {
                if (validUser.IsAdmin)
                {
                    HttpContext.Session.SetString("user", validUser.Username);
                    HttpContext.Session.SetString("rights", "admin");
                    return Redirect("/Index");
                }
                HttpContext.Session.SetString("user", validUser.Username);
                HttpContext.Session.SetString("rights", "normal");
                return Redirect("/Index");
            }

            HttpContext.Session.SetString("erMessage", "Wrong password or email");
            return Page();
        }
    }
}