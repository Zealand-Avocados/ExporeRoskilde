using System;
using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using ExploreRoskilde.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreRoskilde.Catalogs
{
   
    public class UsersCatalog : IUsersCatalog
    {
        public Dictionary<string, User> AllUsers() => Database.Database.ReadJsonUsers();

        public User GetUserById(string id)
        {
            return AllUsers()[id];
        }

        public void Register(User user)
        {
            Dictionary<string, User> users = AllUsers();
            PasswordHasher<string> pw = new PasswordHasher<string>();
            string passwordHashed = pw.HashPassword(user.Email, user.Password);
            user.Password = passwordHashed;
            users.Add(user.Id, user);
            Database.Database.WriteToJsonUsers(users);
        }
        
        public User Login(string email , string password)
        {
            User loggedIn = new User();
            foreach (var (_, value) in AllUsers())
            {
                if (value.Email != email) continue;
                string jsonPassword = value.Password; 
                PasswordHasher<string> pw = new PasswordHasher<string>();
                var verificationResult = pw.VerifyHashedPassword(email, jsonPassword, password);
                loggedIn = verificationResult == PasswordVerificationResult.Success ? value : null;

                return loggedIn;
            }
            return loggedIn;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
