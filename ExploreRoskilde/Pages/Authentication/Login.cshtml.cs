using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public string Username { get; set; }
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }

        public LoginModel(IUsersCatalog service)
        {
            userService = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            return CheckLogin();
        }


        private IActionResult CheckLogin()
        {
            User validUser = userService.Login(Email, Password);
            if (validUser != null)
            {
                if (validUser.IsAdmin)
                {
                    HttpContext.Session.SetString("right", "admin");
                    HttpContext.Session.SetString("user", validUser.Username);
                    return Redirect("~/Item/GetAllItems");
                }

                HttpContext.Session.SetString("right", "user");
                HttpContext.Session.SetString("user", validUser.Username);
                return Redirect("/Index");
            }

            return RedirectToPage("Login");
        }
    }
}